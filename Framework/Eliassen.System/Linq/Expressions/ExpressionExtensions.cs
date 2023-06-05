using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    public static class ExpressionExtensions
    {

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
                    (_, null) => null,
                    (null, _) => expression.Body,
                    (_, _) => type switch
                    {
                        ChainTypes.AndAlso => Expression.AndAlso(chain, expression.Body),
                        ChainTypes.OrElse => Expression.OrElse(chain, expression.Body),
                        _ => throw new NotSupportedException($"{type}")
                    }
                };
            }

            if (chain == null) return null;

            var parameter = Expression.Parameter(typeof(TModel), "n");
            var replaced = new ParameterReplacer(parameter).Visit(chain);
            var lambda = Expression.Lambda<Func<TModel, bool>>(replaced, parameter);
            return lambda;
        }
    }
}
