
namespace StringCalculator
{
    public class Program
    {
        public static void Main()
        {
            string UserSelection = string.Empty;

            PrintMenu();
            _ = int.TryParse(Console.ReadLine()!, out int selectedOperation);

            do
            {
                while (selectedOperation < 1 || selectedOperation > 4)
                {
                    Console.WriteLine("Invalid Operation selected. Please try again");
                    PrintMenu();
                    Console.WriteLine();

                    _ = int.TryParse(Console.ReadLine()!, out selectedOperation);
                }

                HandleOperation(selectedOperation);

                Console.WriteLine("Select an Operation to continue");
                Console.WriteLine("If not, Press Ctrl+C to Exit the App");

                PrintMenu();
                _ = int.TryParse(Console.ReadLine()!, out selectedOperation);
            }
            while (true);
        }

        public static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select an Operation");
            Console.WriteLine();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine();
        }

        public static void HandleOperation(int selectedOperation)
        {
            var operationName = selectedOperation switch
            {
                1 => "Added",
                2 => "Subtracted",
                3 => "Multipled",
                4 => "Divided",
                _ => ""
            };

            Console.WriteLine();
            Console.WriteLine($"Enter formatted string input containing the numbers to be {operationName}");
            Console.WriteLine();

            string inputs = Console.ReadLine()!;

            Console.WriteLine();

            StringCalculator.PerformOperation(inputs, selectedOperation);
        }
    }
}
