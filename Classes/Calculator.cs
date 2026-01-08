public class Calculator
{
    //* Integer-version of methods
    public int AddNumbers(int a, int b)
    {
        return a + b;
    }

    public int SubtractNumbers(int a, int b)
    {
        return a - b;
    }
    public int MultiplyNumbers(int a, int b)
    {
        return a * b;
    }
    public bool TryDivideNumbers(int a, int b, out int result)
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

    public double AddNumbers(double a, double b)
    {
        return a + b;
    }
    public double SubtractNumbers(double a, double b)
    {
        return a - b;
    }
    public double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }
    public bool TryDivideNumbers(double a, double b, out double result)
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