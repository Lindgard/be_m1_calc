namespace be_m1_calc.Classes;

public class Calculator
{
    public int AddNumbers(int a, int b) => a + b;
    public int SubtractNumbers(int a, int b) => a - b;
    public int MultiplyNumbers(int a, int b) => a * b;
    public int tryDivideNumbers(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error! Cannot divide by zero(0)!");
            Console.ResetColor();
            return 0;
        }
        return numerator / denominator;
    }
    //* Double overload av metodene
    public double AddNumbers(double a, double b) => a + b;
    public double SubtractNumbers(double a, double b) => a - b;
    public double MultiplyNumbers(double a, double b) => a * b;
    public double tryDivideNumbers(double numerator, double denominator)
    {
        if (denominator == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u10060 Error! Cannot divide by zero(0)!");
            Console.ResetColor();
            return 0;
        }
        return numerator / denominator;
    }
}