using Xunit;

namespace StringCalculatorUnitTest
{
    public class SupportNewLineCharacterAsAlternativeDelimiterUnitTests
    {
        [Fact]
        public void Support_a_newline_character_as_alternative_delimiter()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(@"1\n2,3", 1);

            Assert.Equal(6, operationResult);
        }
    }
}