namespace Benchmarks.Expression
{
    using System.Linq;
    
    using BenchmarkDotNet.Attributes;
    
    public class ExpressionsTests
    {
        /// <summary>
        /// The initial values array.
        /// </summary>
        private int[] initialValuesArray;

        [Setup]
        public void SetupData()
        {
            const int MaxCounter = 1000;
            this.initialValuesArray = Enumerable.Range(0, MaxCounter).ToArray();
        }

        [Benchmark(Description = "Call")]
        public int Call()
        {
            return this.Run(new Caller());
        }

        [Benchmark(Description = "Compile")]
        public int Compile()
        {
            return this.Run(new Compiler());
        }

        [Benchmark(Description = "Log and Call")]
        public int DoubleUsage()
        {
            return this.Run(new DoubleString());
        }

        public class TestAgent : ICaller
        {
            public int Test(int value)
            {
                return value + 8;
            }
        }

        private int Run(ICaller caller)
        {
            var counter = 0;
            for (int i = 0; i < this.initialValuesArray.Length; i++)
            {
                counter += caller.Test(this.initialValuesArray[i]);
            }

            return counter;
        }
    }
}
