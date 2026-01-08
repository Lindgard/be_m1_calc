public class Calculator
{
    //* Integer-version of methods
    int AddNumbers(int a, int b)
    {
        return a + b;
    }

    int SubtractNumbers(int a, int b)
    {
        return a - b;
    }
    int MultiplyNumbers(int a, int b)
    {
        return a * b;
    }
    bool TryDivideNumbers(int a, int b, out int result)
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

    double AddNumbers(double a, double b)
    {
        return a + b;
    }
    double SubtractNumbers(double a, double b)
    {
        return a - b;
    }
    double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }
    bool TryDivideNumbers(double a, double b, out double result)
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