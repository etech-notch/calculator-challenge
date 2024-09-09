using System;
using Xunit;

namespace StringCalculatorUnitTest
{
    public class SupportOneCustomDelimiterOfASingleCharacterUnitTests
    {
        [Fact]
        public void Support_one_custom_delimiter_of_a_single_character1()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(@"//#\n2#5", 1);

            Assert.Equal(7, operationResult);
        }

        [Fact]
        public void Support_one_custom_delimiter_of_a_single_character2()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(@"//,\n2,ff,100", 1);

            Assert.Equal(102, operationResult);
        }
    }
}