namespace Benchmarks.Expression
{
    public class DoubleString : ICaller
    {
        public int Test(int value)
        {
            Invoker<ExpressionsTests.TestAgent>.Log(targetService => targetService.Test(value));
            return Invoker<ExpressionsTests.TestAgent>.Call(targetService => targetService.Test(value));
        }
    }
}