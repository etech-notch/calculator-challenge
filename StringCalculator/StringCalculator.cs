using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static (int, string) PerformOperation(string inputs, int selectedOperation)
        {
            int operationResult = 0;
            string operationExpression;

            if (string.IsNullOrWhiteSpace(inputs))
            {
                (operationResult, operationExpression) = (0, "0");
            }
            else
            {
                (operationResult, operationExpression) = performOperationWithDelimiter(inputs, ",", selectedOperation);
            }

            PrintResult(inputs, operationExpression, operationResult);

            return (operationResult, operationExpression);
        }

        private static (int, string) performOperationWithDelimiter(string inputs, string delimiter, int selectedOperation)
        {
            string[] inputsAsArray = inputs.Split(delimiter);
            var subInpoutArray = new List<string>();

            foreach (var strg in inputsAsArray)
            {
                string[] strgAsArray = strg.Split("\\n");

                subInpoutArray.AddRange(strgAsArray.ToList());
            }

            inputsAsArray = subInpoutArray.ToArray();

            bool inputsAreNumbers = inputsAsArray.All(u =>
            {
                if (int.TryParse(u, out int numb))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            if (!inputsAreNumbers && delimiter.Equals(",") && inputsAsArray.Length > 2)
            {
                throw new Exception($"Inputs with more than 2 numbers are not allowed when using comma as delimiter: {inputs}");
            }

            int sumResults = 0, inputAsInt;
            string operationExpression = "", negativeConstraint = "";

            foreach (var input in inputsAsArray)
            {
                var trimedInput = input.Replace("\n", "");

                if (!int.TryParse(trimedInput, out inputAsInt))
                {
                    inputAsInt = 0;
                }


                if (inputAsInt < 0)
                {
                    negativeConstraint = negativeConstraint + trimedInput + " ";
                }
                else
                {
                    switch (selectedOperation)
                    {
                        case 1:
                            operationExpression = operationExpression + inputAsInt + "+";
                            sumResults += inputAsInt;
                            break;
                        case 2:
                            operationExpression = operationExpression + inputAsInt + "-";
                            sumResults -= inputAsInt;
                            break;
                        case 3:
                            operationExpression = operationExpression + inputAsInt + "*";
                            sumResults *= inputAsInt;
                            break;
                        case 4:
                            operationExpression = operationExpression + inputAsInt + "/";
                            sumResults /= inputAsInt;
                            break;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(negativeConstraint))
            {
                throw new Exception($"Negative numbers are not allowed:  {negativeConstraint}");
            }

            operationExpression = operationExpression.Remove(operationExpression.Length - 1);
            return (sumResults, operationExpression);
        }

        public static void PrintResult(string inputs, string operationExpression, int operationResult)
        {
            Console.WriteLine();
            Console.WriteLine("{0} will return {1} = {2}", inputs, operationExpression, operationResult);
            Console.WriteLine();
        }
    }
}