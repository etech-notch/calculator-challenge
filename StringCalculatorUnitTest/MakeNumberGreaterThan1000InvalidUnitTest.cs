using Newtonsoft.Json.Linq;
using Xunit;

namespace StringCalculatorUnitTest
{
    public class MakeNumberGreaterThan1000InvalidUnitTest
    {
        [Fact]
        public void Make_any_value_greater_than_1000_invalid()
        {
            var (operationResult, operationExpression) = StringCalculator.StringCalculator.PerformOperation("2,1001,6", 1);

            Assert.Equal(8, operationResult);
        }
    }
}