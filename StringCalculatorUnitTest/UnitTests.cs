using Xunit;

namespace StringCalculatorUnitTest
{
    public class UnitTests
    {
        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter1()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("20", 1);

            Assert.Equal(20, operationResult);
        }

        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter2()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("1,5000", 1);

            Assert.Equal(5001, operationResult);
        }

        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter3()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("4,-3", 1);

            Assert.Equal(1, operationResult);
        }

        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter4()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("", 1);

            Assert.Equal(0, operationResult);
        }
        
        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter5()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation(" ", 1);

            Assert.Equal(0, operationResult);
        }
        
        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter6()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("yy", 1);

            Assert.Equal(0, operationResult);
        }
        
        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter7()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("5, tytyt", 1);

            Assert.Equal(5, operationResult);
        }

        [Fact]
        public void Support_a_maximum_of_two_numbers_using_comma_delimiter8()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("5, tytyt", 1);

            Assert.Equal(5, operationResult);
        }
    }
}