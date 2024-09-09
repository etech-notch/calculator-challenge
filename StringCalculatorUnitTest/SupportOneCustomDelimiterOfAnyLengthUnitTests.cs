using Xunit;

namespace StringCalculatorUnitTest
{
    public class SupportOneCustomDelimiterOfAnyLengthUnitTests
    {
        [Fact]
        public void Support_one_custom_delimiter_of_any_length()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(@"//[***]\n11***22***33", 1);

            Assert.Equal(66, operationResult);
        }
    }
}