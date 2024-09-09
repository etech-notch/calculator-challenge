using Xunit;

namespace StringCalculatorUnitTest
{
    public class SupportMultipleDelimiterOfAnyLengthUnitTests
    {
        [Fact]
        public void Support_multiple_delimiter_of_any_length()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(@"//[*][!!][r9r]\n11r9r22*hh*33!!44", 1);

            Assert.Equal(110, operationResult);
        }
    }
}