using Xunit;

namespace StringCalculatorUnitTest
{
    public class DenyNegativeNumbersUnitTests
    {
        [Fact]
        public void Deny_negative_numbers()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(@"1\n-2,-3", 1);

            Assert.True(operationResult > -1);
        }
    }
}