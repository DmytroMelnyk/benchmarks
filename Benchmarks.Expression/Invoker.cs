namespace Benchmarks.Expression
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Unified remote service invoker.
    /// </summary>
    /// <typeparam name="TService">
    /// Target Service.
    /// </typeparam>
    public static class Invoker<TService>
        where TService : class, new()
    {
        public static TService Service { get; set; } = new TService();

        /// <summary>
        /// Safe invoke of service method with non-void return type.
        /// </summary>
        /// <param name="function">Service call.</param>
        /// <typeparam name="TResult">Server response object type.</typeparam>
        /// <returns>Service response.</returns>
        public static TResult Call<TResult>(Func<TService, TResult> function)
        {
            return function(Service ?? new TService());
        }

        /// <summary>
        /// Safe invoke of service method with non-void return type.
        /// </summary>
        /// <param name="expression">Service call.</param>
        /// <typeparam name="TResult">Server response object type.</typeparam>
        /// <returns>Service response.</returns>
        public static TResult Comple<TResult>(Expression<Func<TService, TResult>> expression)
        {
            var func = expression.LogAndCompile(_ => { });
            return func(Service ?? new TService());
        }
        
        /// <summary>
        /// Safe invoke of service method with non-void return type.
        /// </summary>
        /// <typeparam name="TResult">
        /// Return type.
        /// </typeparam>
        /// <param name="expression">
        /// The expression.
        /// </param>
        public static void Log<TResult>(Expression<Func<TService, TResult>> expression)
        {
            expression.Log(_ => { });
        }
    }
}