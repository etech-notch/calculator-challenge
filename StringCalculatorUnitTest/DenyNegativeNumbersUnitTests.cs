using Xunit;

namespace StringCalculatorUnitTest
{
    public class DenyNegativeNumbersUnitTests
    {
        [Fact]
        public void Deny_negative_numbers()
        {
            Assert.Throws<Exception>(() => StringCalculator.StringCalculator.PerformOperation(@"1\n-2,-3", 1));
        }
    }
}