using Eliassen.System.ComponentModel.Search;
using Eliassen.System.Linq.Search;
using Eliassen.System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Eliassen.System.Linq.Expressions
{
    public class ExpressionTreeBuilder<TModel> : IExpressionTreeBuilder<TModel>
    {
        private const string PropertyMap = nameof(PropertyMap);
        private const string PredicateMap = nameof(PredicateMap);

        public Expression<Func<TModel, bool>>? GetPredicateExpression(
            string name,
            FilterParameter value,
            StringComparison stringComparison
            ) =>
            (TryGetPredicateExpression(name, value, out var expression, stringComparison) ?
                expression : null);

        public Expression<Func<TModel, bool>>? BuildExpression(object? queryParameter, StringComparison stringComparison) =>
            ExpressionExtensions.OrChain(
                from searchExpression in GetSearchableExpressions(stringComparison)
                let builtExpression = BuildPredicate(searchExpression.expression, Operators.EqualTo, queryParameter)
                where builtExpression != null
                select builtExpression
            );

        private IReadOnlyCollection<KeyValuePair<string, Expression<Func<TModel, object>>>> BuildExpressions() =>
            (
            from pi in typeof(TModel).GetProperties(ReflectionExtensions.PublicProperties)
            let exp = BuildExpression(pi)
            where exp != null
            select KeyValuePair.Create(pi.Name, exp)
            ).ToArray();

        private IEnumerable<Expression<Func<TModel, bool>>?> GetPredicates(
            Expression<Func<TModel, object>>? expression,
            FilterParameter? search)
        {
            if (search == null) yield break;

            yield return BuildPredicate(expression, Operators.EqualTo, search.EqualTo);
            yield return BuildPredicate(expression, Operators.NotEqualTo, search.NotEqualTo);
            yield return BuildPredicate(expression, Operators.InSet, search.InSet);
            yield return BuildPredicate(expression, Operators.LessThan, search.LessThan);
            yield return BuildPredicate(expression, Operators.LessThanOrEqualTo, search.LessThanOrEqualTo);
            yield return BuildPredicate(expression, Operators.GreaterThan, search.GreaterThan);
            yield return BuildPredicate(expression, Operators.GreaterThanOrEqualTo, search.GreaterThanOrEqualTo);
        }

        private Expression<Func<TModel, bool>>? BuildPredicate(
            Expression<Func<TModel, object>>? expression,
            FilterParameter? search
            ) => GetPredicates(expression, search).AndChain();

        private Expression<Func<TModel, bool>>? BuildPredicate(
            Expression<Func<TModel, object>>? expression,
            Operators expressionOperator,
            object? queryParameter)

        {
            if (expression == null || queryParameter == null) return null;
            if (queryParameter is FilterParameter search) return BuildPredicate(expression, search);

            Expression unwrapped = expression.Body;
            if ((expression.Body.NodeType == ExpressionType.Convert) ||
                (expression.Body.NodeType == ExpressionType.ConvertChecked))
            {
                if (expression.Body is UnaryExpression unary)
                {
                    unwrapped = unary.Operand;
                }
            }

            if (queryParameter is not string)
            {
                queryParameter = queryParameter switch
                {
                    IEnumerable<char> charArray => new string(charArray.ToArray()),
                    Array _ => queryParameter,
                    IEnumerable enumerable => enumerable.OfType<object>().ToArray(),
                    _ => Convert.ToString(queryParameter)
                };
            }

            var queryParameterType = queryParameter.GetType();

            if (expressionOperator == Operators.InSet)
            {
                if (queryParameterType.IsArray) //TODO: should support IEnumerable<> as well
                {
                    var elementType = queryParameterType.GetElementType();
                    if (elementType == unwrapped.Type)
                    {
                        var enumerable = typeof(IEnumerable<>).MakeGenericType(elementType);

                        Expression<Func<object, bool>> model = e => Enumerable.Contains((object[])queryParameter, e);
                        var containsMethod = (model.Body as MethodCallExpression)?.Method.GetGenericMethodDefinition().MakeGenericMethod(elementType);
                        if (containsMethod != null)
                        {
                            var containsCall = Expression.Call(method: containsMethod, Expression.Constant(queryParameter), unwrapped);
                            var parameter = Expression.Parameter(typeof(TModel), "n");
                            var replaced = new ParameterReplacer(parameter).Visit(containsCall);
                            var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                            return lambda;
                        }
                    }
                    else
                    {
                        var safeArray = unwrapped.Type.MakeSafeArray((Array)queryParameter);
                        if (safeArray != null)
                        {
                            var recursive = BuildPredicate(expression, expressionOperator, safeArray);
                            if (recursive != null) return recursive;
                        }
                    }
                }
                throw new NotSupportedException($"{nameof(expressionOperator)}: {expressionOperator} does not support \"{queryParameterType}\"");

            }

            if (queryParameter is string queryString) //TODO: should be "like"
            {
                if (queryString[..1] == "!")
                {
                    return BuildPredicate(expression, Operators.NotEqualTo, queryString[1..]);
                }
                else if (unwrapped.Type == typeof(string))
                {
                    if (expressionOperator == Operators.NotEqualTo)
                    {
                        var eq = BuildPredicate(expression, Operators.EqualTo, queryParameter);
                        var predicate = Expression.Not(eq.Body);
                        var parameter = Expression.Parameter(typeof(TModel), "n");
                        var replaced = new ParameterReplacer(parameter).Visit(predicate);
                        var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                        return lambda;
                    }
                    else
                    {
                        var (method, queryValue) = (queryString[..1], queryString[^1..]) switch
                        {
                            ("*", "*") => (
                                typeof(string).GetInstanceMethod(nameof(string.Contains), typeof(string)),
                                queryString[1..^1]
                                ),

                            ("*", _) => (
                                typeof(string).GetInstanceMethod(nameof(string.EndsWith), typeof(string)),
                                queryString[1..]
                                ),

                            (_, "*") => (
                                typeof(string).GetInstanceMethod(nameof(string.StartsWith), typeof(string)),
                                queryString[..^1]
                                ),

                            (_, _) => (
                                typeof(string).GetInstanceMethod(nameof(string.Equals), typeof(string)),
                                queryString
                                )
                        };
                        if (method == null) throw new NotSupportedException("Method not defined");

                        var predicate = Expression.Call(unwrapped, method, Expression.Constant(queryValue));

                        var parameter = Expression.Parameter(typeof(TModel), "n");
                        var replaced = new ParameterReplacer(parameter).Visit(predicate);
                        var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                        return lambda;
                    }
                }
                else if (unwrapped.Type.TryParse(queryString, out var value))
                {
                    queryParameter = value;
                }
            }

            if (unwrapped.Type == queryParameter?.GetType())
            {
                //TODO: needs to be a bit more creative.  type casting not supported
                var parameter = Expression.Parameter(typeof(TModel), "n");
                var predicate = expressionOperator.BuildBinaryExpression(unwrapped, queryParameter);
                var replaced = new ParameterReplacer(parameter).Visit(predicate);
                var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                return lambda;
            }
            else
            {
                return default;
            }
        }

        public IReadOnlyDictionary<string, Expression<Func<TModel, object>>> PropertyExpressions() =>
            new Dictionary<string, Expression<Func<TModel, object>>>(BuildExpressions(), StringComparer.InvariantCultureIgnoreCase);

        public IReadOnlyCollection<string> GetSearchablePropertyNames()
        {
            var modelType = typeof(TModel);

            var properties = modelType
                .GetCustomAttributes<SearchableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        from attrib in prop.GetCustomAttributes<SearchableAttribute>()
                        select attrib.TargetName ?? prop.Name)
                .Distinct();

            if (!properties.Any())
            {
                properties = modelType.GetProperties(ReflectionExtensions.PublicProperties).Select(p => p.Name).Distinct();
            }

            var notSearchable = modelType
                .GetCustomAttributes<NotSearchableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        from attrib in prop.GetCustomAttributes<NotSearchableAttribute>()
                        select attrib.TargetName ?? prop.Name)
                .Distinct();

            var results = properties
                .Except(notSearchable)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Cast<string>()
                .ToArray();

            return results;
        }

        public IReadOnlyCollection<string> GetSortablePropertyNames()
        {
            var modelType = typeof(TModel);

            var properties = modelType
                .GetCustomAttributes<SearchableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        select prop.Name)
                .Distinct();

            var notSearchable = modelType
                .GetCustomAttributes<NotSortableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        from attrib in prop.GetCustomAttributes<NotSortableAttribute>()
                        select attrib.TargetName ?? prop.Name)
                .Distinct();

            var results = properties
                .Except(notSearchable)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Cast<string>()
                .ToArray();

            return results;
        }

        public IReadOnlyCollection<string> GetFilterablePropertyNames()
        {
            var modelType = typeof(TModel);

            var searchableProperties = modelType
                .GetCustomAttributes<SearchableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        select prop.Name)
                .Distinct();

            var properties = modelType
                .GetCustomAttributes<FilterableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        select prop.Name)
                .Distinct();

            var notSearchable = modelType
                .GetCustomAttributes<NotFilterableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        from attrib in prop.GetCustomAttributes<NotFilterableAttribute>()
                        select attrib.TargetName ?? prop.Name)
                .Distinct();

            var results =
                searchableProperties
                .Concat(properties)
                .Except(notSearchable)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Cast<string>()
                .ToArray();

            return results;
        }

        public IReadOnlyCollection<(string column, OrderDirections direction)> DefaultSortOrder() =>
            (
                from attribute in typeof(TModel).GetCustomAttributes<DefaultSortAttribute>()
                where !string.IsNullOrWhiteSpace(attribute.TargetName)
                select (name: attribute.TargetName, attribute.Order, attribute.Priority)
            ).Concat(
                from prop in typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)
                let attribute = prop.GetCustomAttribute<DefaultSortAttribute>()
                where attribute != null
                select (name: attribute.TargetName ?? prop.Name, attribute.Order, attribute.Priority)
            ).OrderBy(p => p.Priority).Select(o => (o.name, o.Order))
            .ToArray();

        private IReadOnlyCollection<(string property, Expression<Func<TModel, object>> expression)> GetSearchableExpressions(StringComparison stringComparison) =>
            (
            from property in GetSearchablePropertyNames()
            let expression = TryGetPropertyExpression(property, out var exp, stringComparison) ? exp : null
            where expression != null
            select (property, expression)
            ).ToArray();

        private Expression<Func<TModel, object>>? BuildExpression(PropertyInfo? prop)
        {
            if (prop == null) return null;
            var parameter = Expression.Parameter(typeof(TModel), "n");
            Expression property = Expression.Property(parameter, prop);

            if (!prop.PropertyType.IsClass)
                property = Expression.Convert(property, typeof(object));

            var exp = Expression.Lambda<Func<TModel, object>>(property, parameter);

            return exp;
        }

        private bool TryGetPredicateExpression(
            string name,
            FilterParameter value,
            out Expression<Func<TModel, bool>>? expression,
            StringComparison stringComparison
            )
        {
            var modelType = typeof(TModel);

            expression = modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(FilterParameter))
                ?.Invoke(null, new object[] { name, value }) as Expression<Func<TModel, bool>>;

            expression ??= modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(FilterParameter), typeof(StringComparison))
                ?.Invoke(null, new object[] { name, value, stringComparison }) as Expression<Func<TModel, bool>>;

            if (value.EqualTo != null)
            {
                expression = modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(object))
                    ?.Invoke(null, new object[] { name, value.EqualTo }) as Expression<Func<TModel, bool>>;

                expression ??= modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(object), typeof(StringComparison))
                    ?.Invoke(null, new object[] { name, value.EqualTo, stringComparison }) as Expression<Func<TModel, bool>>;
            }

            //TODO: should I add support to unroll the searchOption?

            expression ??= BuildPredicate(GetPropertyExpression(name, stringComparison), value);

            return expression != null;
        }

        private Expression<Func<TModel, object>>? GetPropertyExpression(
            string name,
            StringComparison stringComparison
            ) =>
            (TryGetPropertyExpression(name, out var expression, stringComparison) ?
                expression : null);

        private bool TryGetPropertyExpression(
            string name,
            out Expression<Func<TModel, object>>? expression,
            StringComparison stringComparison
            )
        {
            var modelType = typeof(TModel);

            expression = modelType.GetStaticMethod(PropertyMap, typeof(string))
                ?.Invoke(null, new[] { name }) as Expression<Func<TModel, object>>;

            expression ??= modelType.GetStaticMethod(PropertyMap, typeof(string), typeof(StringComparison))
                ?.Invoke(null, new object[] { name, stringComparison }) as Expression<Func<TModel, object>>;

            expression ??= BuildExpression(
                modelType.GetProperties(ReflectionExtensions.PublicProperties)
                .FirstOrDefault(pi => string.Equals(pi.Name, name, stringComparison))
                );

            return expression != null;
        }

    }
}
