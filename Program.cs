//* Main entry point of the calculator application
//* This class handles user interaction (input/output) and delegates business logic to CalculatorService
class Program
{
    static void Main(string[] args)
    {
        //* Create an instance of CalculatorService to handle calculations
        CalculatorService service = new CalculatorService();

        //* Infinite loop to keep the calculator running until user types "exit"
        while (true)
        {
            //* Get first number from user
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter first number \nPress Enter when done: ");
            Console.ResetColor();
            string? input1 = Console.ReadLine();

            //* Allow user to exit at any time by typing "exit"
            if (input1?.ToLower() == "exit") break;

            //* Validate and parse the first number using the service layer
            //* If parsing fails, show error and restart the loop
            if (!service.TryParseNumber(input1, out double num1))
            {
                Console.WriteLine("Invalid number. Please try again.");
                continue;
            }

            //* Get second number from user
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter second number \nPress Enter when done: ");
            Console.ResetColor();
            string? input2 = Console.ReadLine();

            //* Allow user to exit at any time by typing "exit"
            if (input2?.ToLower() == "exit") break;

            //* Validate and parse the second number using the service layer
            //* If parsing fails, show error and restart the loop
            if (!service.TryParseNumber(input2, out double num2))
            {
                Console.WriteLine("Invalid number. Please try again.");
                continue;
            }

            //* Get the mathematical operation from user
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter operator (+, -, *, /): ");
            Console.ResetColor();
            string? operation = Console.ReadLine();

            //* Allow user to exit at any time by typing "exit"
            if (operation?.ToLower() == "exit") break;

            //* Validate that operation is not empty or null
            if (string.IsNullOrEmpty(operation))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation. Please try again.");
                Console.ResetColor();
                continue;
            }

            //* Perform the calculation through the service layer
            //* The method returns false if calculation fails (invalid operation or division by zero)
            //* It also returns which method type was used (int or double) via the methodType parameter
            if (!service.PerformCalculation(num1, operation ?? "", num2, out double result, out string methodType))
            {
                //* Display error message if calculation failed
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation or division by zero. Please try again.");
                Console.ResetColor();
                continue;
            }
            else
            {
                //* Display successful result with method type information
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result} ({methodType})");
                Console.ResetColor();
                continue;
            }
        }
    }
}