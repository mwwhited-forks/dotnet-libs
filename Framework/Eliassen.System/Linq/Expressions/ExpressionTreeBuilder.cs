using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Eliassen.System.ComponentModel;
using Eliassen.System.Reflection;

namespace Eliassen.System.Linq.Expressions
{
    public static class ExpressionTreeBuilder
    {
        public static IDictionary<string, Expression<Func<TModel, object>>> PropertyExpressions<TModel>() =>
         new Dictionary<string, Expression<Func<TModel, object>>>(BuildExpressions<TModel>(), StringComparer.InvariantCultureIgnoreCase);

        public static IEnumerable<KeyValuePair<string, Expression<Func<TModel, object>>>> BuildExpressions<TModel>() =>
            from pi in typeof(TModel).GetProperties(ReflectionExtensions.PublicProperties)
            let exp = pi.BuildExpression<TModel>()
            where exp != null
            select KeyValuePair.Create(pi.Name, exp);

        public static Expression<Func<TModel, bool>>? BuildPredicate<TModel>(
            this Expression<Func<TModel, object>>? expression,
            object? queryParameter
            )
        {
            if (expression == null || queryParameter == null) return null;

            Expression unwrapped = expression.Body;
            if ((expression.Body.NodeType == ExpressionType.Convert) ||
                (expression.Body.NodeType == ExpressionType.ConvertChecked))
            {
                if (expression.Body is UnaryExpression unary)
                {
                    unwrapped = unary.Operand;
                }
            }

            if (!(queryParameter is string))
            {
                queryParameter = queryParameter switch
                {
                    IEnumerable<char> charArray => new string(charArray.ToArray()),
                    Array _ => queryParameter,
                    IEnumerable enumerable => enumerable.OfType<object>().ToArray(),
                    _ => Convert.ToString(queryParameter)
                };
            }

            //TODO: consider some sort of "range" support

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
                        var recursive = BuildPredicate<TModel>(expression, safeArray);
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
                            .GetMethod(name: nameof(string.Contains), bindingAttr: ReflectionExtensions.PublicInstanceMethod, binder: null, new[] { typeof(string) }, modifiers: null)
                            ?? throw new NotSupportedException();
                        predicate = Expression.Call(unwrapped, method, Expression.Constant(queryString.Trim('*')));
                    }
                    else if (queryString.StartsWith('*'))
                    {
                        var method = typeof(string)
                            .GetMethod(name: nameof(string.EndsWith), bindingAttr: ReflectionExtensions.PublicInstanceMethod, binder: null, new[] { typeof(string) }, modifiers: null)
                            ?? throw new NotSupportedException();
                        predicate = Expression.Call(unwrapped, method, Expression.Constant(queryString.TrimStart('*')));
                    }
                    else if (queryString.EndsWith('*'))
                    {
                        var method = typeof(string)
                            .GetMethod(name: nameof(string.StartsWith), bindingAttr: ReflectionExtensions.PublicInstanceMethod, binder: null, new[] { typeof(string) }, modifiers: null)
                            ?? throw new NotSupportedException();
                        predicate = Expression.Call(unwrapped, method, Expression.Constant(queryString.TrimEnd('*')));
                    }
                    else
                    {
                        predicate = Expression.Equal(unwrapped, Expression.Constant(queryString));
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
                var replaced = new ParameterReplacer(parameter).Visit(Expression.Equal(unwrapped, Expression.Constant(queryParameter)));
                var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
                return lambda;
            }
            else
            {
                return default;
            }
        }

        public static Expression<Func<TModel, bool>>? BuildExpression<TModel>(object? queryParameter) =>
            OrChain(
                from searchExpression in GetSearchableExpressions<TModel>()
                let builtExpression = searchExpression.expression.BuildPredicate(queryParameter)
                where builtExpression != null
                select builtExpression
            );

        public static IEnumerable<string> GetSearchablePropertyNames<TModel>()
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

        public static IEnumerable<string> GetSortablePropertyNames<TModel>()
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

        public static IEnumerable<string> GetFilterablePropertyNames<TModel>()
        {
            var modelType = typeof(TModel);

            var properties = modelType
                .GetCustomAttributes<SearchableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        select prop.Name)
                .Distinct();

            var notSearchable = modelType
                .GetCustomAttributes<NotFilterableAttribute>().Select(a => a.TargetName)
                .Concat(from prop in modelType.GetProperties(ReflectionExtensions.PublicProperties)
                        from attrib in prop.GetCustomAttributes<NotFilterableAttribute>()
                        select attrib.TargetName ?? prop.Name)
                .Distinct();

            var results = properties
                .Except(notSearchable)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Cast<string>()
                .ToArray();

            return results;
        }



        public static IEnumerable<(string property, Expression<Func<TModel, object>> expression)> GetSearchableExpressions<TModel>() =>
            from property in GetSearchablePropertyNames<TModel>()
            let expression = TryGetExpression<TModel>(property, out var exp) ? exp : null
            where expression != null
            select (property, expression);

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

        public static Expression<Func<TModel, object>>? GetExpression<TModel>(
            string name,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            ) =>
            (TryGetExpression<TModel>(name, out var expression, stringComparison) ?
                expression : null);

        public static bool TryGetExpression<TModel>(
            string name,
            out Expression<Func<TModel, object>>? expression,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            )
        {
            var modelType = typeof(TModel);

            expression = modelType
                .GetMethod(name: "PropertyMap", bindingAttr: ReflectionExtensions.PublicStaticMethod, binder: null, new[] { typeof(string) }, modifiers: null)
                ?.Invoke(null, new[] { name }) as Expression<Func<TModel, object>>;

            expression ??= modelType
                .GetMethod(name: "PropertyMap", bindingAttr: ReflectionExtensions.PublicStaticMethod, binder: null, new[] { typeof(StringComparison) }, modifiers: null)
                ?.Invoke(null, new object[] { name, stringComparison }) as Expression<Func<TModel, object>>;

            expression ??= modelType.GetProperties(ReflectionExtensions.PublicProperties).FirstOrDefault(pi => string.Equals(pi.Name, name, stringComparison)).BuildExpression<TModel>();

            return expression != null;
        }

        public static Expression<Func<TModel, bool>>? OrChain<TModel>(
            this Expression<Func<TModel, bool>> or,
            params Expression<Func<TModel, bool>>[] ors
            ) => new[] { or }.Concat(ors).OrChain();
        public static Expression<Func<TModel, bool>>? OrChain<TModel>(this IEnumerable<Expression<Func<TModel, bool>>> ors
        )
        {
            Expression? chain = null;

            foreach (var or in ors.Where(o => o != null))
            {
                chain = (chain, or) switch
                {
                    (null, _) => or.Body,
                    (_, _) => Expression.OrElse(chain, or.Body)
                };
            }

            if (chain == null) return null;

            var parameter = Expression.Parameter(typeof(TModel), "n");
            var replaced = new ParameterReplacer(parameter).Visit(chain);
            var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
            return lambda;
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
