namespace Benchmarks.Expression
{
    using System;
    using System.Linq.Expressions;

    public static class ExpressionHelper
    {
        public static object GetArgumentValue(Expression argument)
        {
            return Expression.Lambda<Func<object>>(Expression.Convert(argument, typeof(object))).Compile().Invoke();
        }
    }
}