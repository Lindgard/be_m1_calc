//* Model class - contains the business logic for the calculator

public class Calculator
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public string Operation { get; set; } = "";
    public double Result { get; set; }
    public string MethodType { get; set; } = "";

    //* Constructor to create calculation model
    public Calculator(double number1, double number2, string operation)
    {
        Number1 = number1;
        Number2 = number2;
        Operation = operation;
    }

    //* Method to format the calculation as a string
    public override string ToString()
    {
        return $"{Number1} {Operation} {Number2} = {Result} ({MethodType})";
    }

    //* Static methods for performing operations
    public static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    public static int SubtractNumbers(int a, int b)
    {
        return a - b;
    }

    public static int MultiplyNumbers(int a, int b)
    {
        return a * b;
    }

    public static bool TryDivideNumbers(int a, int b, out int result)
    {
        if (b == 0)
        {
            result = 0;
            return false;
        }

        result = a / b;
        return true;
    }

    //* Double-version of methods

    public static double AddNumbers(double a, double b)
    {
        return a + b;
    }

    public static double SubtractNumbers(double a, double b)
    {
        return a - b;
    }

    public static double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }

    public static bool TryDivideNumbers(double a, double b, out double result)
    {
        if (b == 0)
        {
            result = 0.0;
            return false;
        }

        result = a / b;
        return true;
    }
}