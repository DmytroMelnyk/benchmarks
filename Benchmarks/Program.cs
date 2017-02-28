namespace Benchmarks
{
    using System;

    using BenchmarkDotNet.Running;

    using Benchmarks.Expression;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExpressionsTests>();
        }
    }
}
