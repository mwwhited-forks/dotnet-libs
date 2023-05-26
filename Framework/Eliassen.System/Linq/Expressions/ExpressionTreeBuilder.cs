using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Eliassen.System.ComponentModel;
using Eliassen.System.Linq.Search;
using Eliassen.System.Reflection;

namespace Eliassen.System.Linq.Expressions
{
    public static class ExpressionTreeBuilder
    {
        public const string PropertyMap = nameof(PropertyMap);
        public const string PredicateMap = nameof(PredicateMap);


        public static IReadOnlyDictionary<string, Expression<Func<TModel, object>>> PropertyExpressions<TModel>() =>
         new Dictionary<string, Expression<Func<TModel, object>>>(BuildExpressions<TModel>(), StringComparer.InvariantCultureIgnoreCase);

        public static IReadOnlyCollection<KeyValuePair<string, Expression<Func<TModel, object>>>> BuildExpressions<TModel>() =>
            (
            from pi in typeof(TModel).GetProperties(ReflectionExtensions.PublicProperties)
            let exp = pi.BuildExpression<TModel>()
            where exp != null
            select KeyValuePair.Create(pi.Name, exp)
            ).ToArray();

        public static IEnumerable<Expression<Func<TModel, bool>>?> GetPredicates<TModel>(
            this Expression<Func<TModel, object>>? expression,
            SearchParameter? search)
        {
            if (search == null) yield break;

            yield return expression.BuildPredicate(search.EqualTo, ExpressionOperators.EqualTo);
            yield return expression.BuildPredicate(search.InSet, ExpressionOperators.InSet);
            yield return expression.BuildPredicate(search.LessThan, ExpressionOperators.LessThan);
            yield return expression.BuildPredicate(search.LessThanOrEqualTo, ExpressionOperators.LessThanOrEqualTo);
            yield return expression.BuildPredicate(search.GreaterThan, ExpressionOperators.GreaterThan);
            yield return expression.BuildPredicate(search.GreaterThanOrEqualTo, ExpressionOperators.GreaterThanOrEqualTo);
        }

        public static Expression<Func<TModel, bool>>? BuildPredicate<TModel>(
            this Expression<Func<TModel, object>>? expression,
            SearchParameter? search
            ) => GetPredicates(expression, search).AndChain();

        private static Expression<Func<TModel, bool>>? BuildPredicate<TModel>(
            this Expression<Func<TModel, object>>? expression,
            object? queryParameter,
            ExpressionOperators expressionOperator
            )

        {
            if (expression == null || queryParameter == null) return null;
            if (queryParameter is SearchParameter search) return expression.BuildPredicate(search);

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

            if (queryParameterType.IsArray) //TODO: this should support IEnumerable<> as well
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
                    var safeArray = ReflectionExtensions.MakeSafeArray(unwrapped.Type, (Array)queryParameter);
                    if (safeArray != null)
                    {
                        var recursive = BuildPredicate<TModel>(expression, safeArray, expressionOperator);
                        if (recursive != null) return recursive;
                    }
                }
            }
            else if (queryParameter is string queryString)
            {
                if (unwrapped.Type == typeof(string))
                {
                    Expression? predicate = null;

                    if (queryString.StartsWith('*') && queryString.EndsWith('*'))
                    {
                        var method = typeof(string)
                            .GetMethod(
                                name: nameof(string.Contains),
                                bindingAttr: ReflectionExtensions.PublicInstanceMethod,
                                binder: null, new[] { typeof(string) },
                                modifiers: null
                                )
                            ?? throw new NotSupportedException();
                        predicate = Expression.Call(unwrapped, method, Expression.Constant(queryString.Trim('*')));
                    }
                    else if (queryString.StartsWith('*'))
                    {
                        var method = typeof(string)
                            .GetMethod(
                                name: nameof(string.EndsWith),
                                bindingAttr: ReflectionExtensions.PublicInstanceMethod,
                                binder: null, new[] { typeof(string) },
                                modifiers: null
                                )
                            ?? throw new NotSupportedException();
                        predicate = Expression.Call(unwrapped, method, Expression.Constant(queryString.TrimStart('*')));
                    }
                    else if (queryString.EndsWith('*'))
                    {
                        var method = typeof(string)
                            .GetMethod(
                                name: nameof(string.StartsWith),
                                bindingAttr: ReflectionExtensions.PublicInstanceMethod,
                                binder: null, new[] { typeof(string) },
                                modifiers: null
                                )
                            ?? throw new NotSupportedException();
                        predicate = Expression.Call(unwrapped, method, Expression.Constant(queryString.TrimEnd('*')));
                    }
                    else
                    {
                        predicate = expressionOperator.BuildBinaryExpression(unwrapped, Expression.Constant(queryParameter));
                    }

                    var parameter = Expression.Parameter(typeof(TModel), "n");
                    var replaced = new ParameterReplacer(parameter).Visit(predicate);
                    var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                    return lambda;
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
                var replaced = new ParameterReplacer(parameter).Visit(expressionOperator.BuildBinaryExpression(unwrapped, Expression.Constant(queryParameter)));
                var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                return lambda;
            }
            else
            {
                return default;
            }
        }

        private static BinaryExpression BuildBinaryExpression(this ExpressionOperators expressionOperator, Expression left, Expression right) =>
            expressionOperator switch
            {
                ExpressionOperators.EqualTo => Expression.Equal(left, right),

                ExpressionOperators.LessThan => Expression.LessThan(left, right),
                ExpressionOperators.LessThanOrEqualTo => Expression.LessThanOrEqual(left, right),
                ExpressionOperators.GreaterThan => Expression.GreaterThan(left, right),
                ExpressionOperators.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(left, right),

                _ => throw new NotSupportedException($"{expressionOperator} is not supported"),
            };

        public static Expression<Func<TModel, bool>>? BuildExpression<TModel>(object? queryParameter) =>
            OrChain(
                from searchExpression in GetSearchableExpressions<TModel>()
                let builtExpression = searchExpression.expression.BuildPredicate(queryParameter, ExpressionOperators.EqualTo)
                where builtExpression != null
                select builtExpression
            );

        public static IReadOnlyCollection<string> GetSearchablePropertyNames<TModel>()
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

        public static IReadOnlyCollection<string> GetSortablePropertyNames<TModel>()
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

        public static IReadOnlyCollection<string> GetFilterablePropertyNames<TModel>()
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

        public static IReadOnlyCollection<(string property, Expression<Func<TModel, object>> expression)> GetSearchableExpressions<TModel>() =>
            (
            from property in GetSearchablePropertyNames<TModel>()
            let expression = TryGetPropertyExpression<TModel>(property, out var exp) ? exp : null
            where expression != null
            select (property, expression)
            ).ToArray();

        public static Expression<Func<TModel, object>>? BuildExpression<TModel>(this PropertyInfo? prop)
        {
            if (prop == null) return null;
            var parameter = Expression.Parameter(typeof(TModel), "n");
            Expression property = Expression.Property(parameter, prop);

            if (!prop.PropertyType.IsClass)
                property = Expression.Convert(property, typeof(object));

            var exp = Expression.Lambda<Func<TModel, object>>(property, parameter);

            return exp;
        }

        public static Expression<Func<TModel, bool>>? GetPredicateExpression<TModel>(
            string name,
            SearchParameter value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            ) =>
            (TryGetPredicateExpression<TModel>(name, value, out var expression, stringComparison) ?
                expression : null);

        public static bool TryGetPredicateExpression<TModel>(
            string name,
            SearchParameter value,
            out Expression<Func<TModel, bool>>? expression,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            )
        {
            var modelType = typeof(TModel);

            expression = modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(SearchParameter))
                ?.Invoke(null, new object[] { name, value }) as Expression<Func<TModel, bool>>;

            expression ??= modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(SearchParameter), typeof(StringComparison))
                ?.Invoke(null, new object[] { name, value, stringComparison }) as Expression<Func<TModel, bool>>;

            if (value.EqualTo != null)
            {
                expression = modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(object))
                    ?.Invoke(null, new object[] { name, value.EqualTo }) as Expression<Func<TModel, bool>>;

                expression ??= modelType.GetStaticMethod(PredicateMap, typeof(string), typeof(object), typeof(StringComparison))
                    ?.Invoke(null, new object[] { name, value.EqualTo, stringComparison }) as Expression<Func<TModel, bool>>;
            }

            //TODO: should I add support to unroll the searchoption?

            expression ??= GetPropertyExpression<TModel>(name)?.BuildPredicate(value);

            return expression != null;
        }

        public static Expression<Func<TModel, object>>? GetPropertyExpression<TModel>(
            string name,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            ) =>
            (TryGetPropertyExpression<TModel>(name, out var expression, stringComparison) ?
                expression : null);

        public static bool TryGetPropertyExpression<TModel>(
            string name,
            out Expression<Func<TModel, object>>? expression,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            )
        {
            var modelType = typeof(TModel);

            expression = modelType.GetStaticMethod(PropertyMap, typeof(string))
                ?.Invoke(null, new[] { name }) as Expression<Func<TModel, object>>;

            expression ??= modelType.GetStaticMethod(PropertyMap, typeof(string), typeof(StringComparison))
                ?.Invoke(null, new object[] { name, stringComparison }) as Expression<Func<TModel, object>>;

            expression ??= modelType.GetProperties(ReflectionExtensions.PublicProperties)
                .FirstOrDefault(pi => string.Equals(pi.Name, name, stringComparison))
                .BuildExpression<TModel>();

            return expression != null;
        }

        public static Expression<Func<TModel, bool>>? OrChain<TModel>(
            this Expression<Func<TModel, bool>> or,
            params Expression<Func<TModel, bool>>[] ors
            ) => new[] { or }.Concat(ors).OrChain();

        public static Expression<Func<TModel, bool>>? OrChain<TModel>(
            this IEnumerable<Expression<Func<TModel, bool>>> ors
        ) => Chain(ors, ChainTypes.OrElse);

        public static Expression<Func<TModel, bool>>? AndChain<TModel>(
            this Expression<Func<TModel, bool>> and,
            params Expression<Func<TModel, bool>>[] ands
            ) => new[] { and }.Concat(ands).AndChain();

        public static Expression<Func<TModel, bool>>? AndChain<TModel>(
            this IEnumerable<Expression<Func<TModel, bool>>?> ands
        ) => Chain(ands, ChainTypes.AndAlso);

        private static Expression<Func<TModel, bool>>? Chain<TModel>(
            IEnumerable<Expression<Func<TModel, bool>>?> expressions, ChainTypes type
        )
        {
            Expression? chain = null;

            foreach (var expression in expressions.Where(o => o != null))
            {
                chain = (chain, expression) switch
                {
                    (null, _) => expression.Body,
                    (_, _) => type switch
                    {
                        ChainTypes.AndAlso => Expression.AndAlso(chain, expression.Body),
                        ChainTypes.OrElse => Expression.OrElse(chain, expression.Body),
                    }
                };
            }

            if (chain == null) return null;

            var parameter = Expression.Parameter(typeof(TModel), "n");
            var replaced = new ParameterReplacer(parameter).Visit(chain);
            var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
            return lambda;
        }

        private enum ChainTypes
        {
            AndAlso,
            OrElse,
        }

        private enum ExpressionOperators
        {
            Unknown,
            EqualTo,
            InSet,
            LessThan,
            LessThanOrEqualTo,
            GreaterThan,
            GreaterThanOrEqualTo,
        }

        internal class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _parameter;

            internal ParameterReplacer(ParameterExpression parameter) =>
                _parameter = parameter;

            protected override Expression VisitParameter(ParameterExpression node) => _parameter;
        }
    }
}
