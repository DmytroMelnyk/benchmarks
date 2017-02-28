namespace Benchmarks.Expression
{
    public class Compiler : ICaller
    {
        public int Test(int value)
        {
            return Invoker<ExpressionsTests.TestAgent>.Comple(targetService => targetService.Test(value));
        }
    }
}