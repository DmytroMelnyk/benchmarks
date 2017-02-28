namespace Benchmarks.Expression
{
    public class Caller : ICaller
    {
        public int Test(int value)
        {
            return Invoker<ExpressionsTests.TestAgent>.Call(targetService => targetService.Test(value));
        }
    }
}