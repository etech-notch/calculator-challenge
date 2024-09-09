using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static (int, string) PerformOperation(string inputs, int selectedOperation)
        {
            try
            {
                int operationResult = 0;
                string operationExpression;

                if (string.IsNullOrWhiteSpace(inputs))
                {
                    (operationResult, operationExpression) = (0, "0");
                }
                else if (CheckDelimiter(inputs))
                {
                    (operationResult, operationExpression) = GetDelimiter(inputs, selectedOperation);
                }
                else
                {
                    var delimiters = new Queue<string>();
                    delimiters.Enqueue(",");

                    if (inputs.Contains("\\n"))
                    {
                        delimiters.Enqueue("\\n");
                    }

                    (operationResult, operationExpression) = performOperationWithDelimiter(inputs, delimiters, selectedOperation);
                }

                PrintResult(inputs, operationExpression, operationResult);

                return (operationResult, operationExpression);
            }catch { throw; }
        }

        private static bool CheckDelimiter(string inputs)
        {
            var inputsAsCharArray = inputs.ToCharArray();

            if (inputsAsCharArray[0] == '/' && inputsAsCharArray[1] == '/')
            {
                return true;
            }
            return false;
        }

        private static (int, string) GetDelimiter(string inputs, int selectedOperation)
        {
            Queue<string> delimiters = new();
            string delimiter = "";
            bool state = true;
            int a = 2, j = 3;
            string subInputs;

            var inputsAsCharArray = inputs.ToCharArray();

            while (state)
            {
                delimiter += inputsAsCharArray[a];

                if (inputsAsCharArray[j] == '\\' || inputsAsCharArray[j] == ']')
                {
                    if (delimiter[0] == '[')
                    {
                        delimiter = delimiter.Remove(0, 1);
                    }

                    delimiters.Enqueue(delimiter);
                    delimiter = "";

                    if (inputsAsCharArray[j + 1] != '[')
                    {
                        state = false;
                    }
                    else
                    {
                        a += 3;
                        j += 3;
                    }
                }
                else
                {
                    a++;
                    j++;
                }
            }

            subInputs = inputs.Substring(inputs.IndexOf('n') + 1);

            return performOperationWithDelimiter(subInputs, delimiters, selectedOperation);
        }

        private static (int, string) performOperationWithDelimiter(string inputs, Queue<string> delimiters, int selectedOperation)
        {
            var inputsAsArray = new List<string>() { inputs };
            var subInpoutArray = new List<string>();
            var usedDelimiters = new List<string>();

            do
            {
                var delimiter = delimiters.Dequeue();
                usedDelimiters.Add(delimiter);

                foreach (var strg in inputsAsArray)
                {
                    string[] strgAsArray = strg.Split(delimiter);

                    subInpoutArray.AddRange(strgAsArray.ToList());
                }

                inputsAsArray = subInpoutArray;
                subInpoutArray = new List<string>();

            } while (delimiters.Count > 0);

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

            if (!inputsAreNumbers && usedDelimiters.All(u => u == ",") && inputsAsArray.Count > 2)
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
                    if (inputAsInt > 1000)
                    {
                        inputAsInt = 0;
                    }

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