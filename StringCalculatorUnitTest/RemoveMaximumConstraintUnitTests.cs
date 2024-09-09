using Xunit;

namespace StringCalculatorUnitTest
{
    public class RemoveMaximumConstraintForNumbersUnitTests
    {
        [Fact]
        public void Remove_the_maximum_constraint_for_number1()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("1,2,3,4,5,6,7,8,9,10,11,12", 1);

            Assert.Equal(78, operationResult);
        }
    }
}