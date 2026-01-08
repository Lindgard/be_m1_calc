using System.ComponentModel.Design;

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
        }
    }
}