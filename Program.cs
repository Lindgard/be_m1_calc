class Program
{
    static void Main(string[] args)
    {
        CalculatorService service = new CalculatorService();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter first number \nPress Enter when done: ");
            Console.ResetColor();
            string? input1 = Console.ReadLine();

            if (input1?.ToLower() == "exit") break;

            if (!service.TryParseNumber(input1, out double num1))
            {
                Console.WriteLine("Invalid number. Please try again.");
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter second number \nPress Enter when done: ");
            Console.ResetColor();
            string? input2 = Console.ReadLine();

            if (input2?.ToLower() == "exit") break;

            if (!service.TryParseNumber(input2, out double num2))
            {
                Console.WriteLine("Invalid number. Please try again.");
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter operator (+, -, *, /): ");
            Console.ResetColor();
            string? operation = Console.ReadLine();

            if (operation?.ToLower() == "exit") break;

            if (string.IsNullOrEmpty(operation))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation. Please try again.");
                Console.ResetColor();
                continue;
            }

            if (!service.PerformCalculation(num1, operation ?? "", num2, out double result, out string methodType))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation or division by zero. Please try again.");
                Console.ResetColor();
                continue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result} ({methodType})");
                Console.ResetColor();
                continue;
            }
        }
    }
}