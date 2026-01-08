//* Business logic layer - contains the core mathematical operations
//* Uses method overloading to provide both integer and double versions of each operation
public class Calculator
{
    //* Integer-version of methods
    //* These methods work with whole numbers only

    //* Adds two integers together
    public int AddNumbers(int a, int b)
    {
        return a + b;
    }

    //* Subtracts the second integer from the first
    public int SubtractNumbers(int a, int b)
    {
        return a - b;
    }

    //* Multiplies two integers together
    public int MultiplyNumbers(int a, int b)
    {
        return a * b;
    }

    //* Divides the first integer by the second
    //* Returns false if division by zero is attempted (b == 0)
    //* Uses 'out' parameter to return the result value
    public bool TryDivideNumbers(int a, int b, out int result)
    {
        //* Check for division by zero - this is not allowed in mathematics
        if (b == 0)
        {
            result = 0;
            return false; //* Indicate failure
        }

        //* Perform integer division (result is truncated, no decimal part)
        result = a / b;
        return true; //* Indicate success
    }

    //* Double-version of methods
    //* These methods work with decimal numbers (floating-point)
    //* Method overloading: same method names but different parameter types

    //* Adds two doubles together
    public double AddNumbers(double a, double b)
    {
        return a + b;
    }

    //* Subtracts the second double from the first
    public double SubtractNumbers(double a, double b)
    {
        return a - b;
    }

    //* Multiplies two doubles together
    public double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }

    //* Divides the first double by the second
    //* Returns false if division by zero is attempted (b == 0)
    //* Uses 'out' parameter to return the result value
    public bool TryDivideNumbers(double a, double b, out double result)
    {
        //* Check for division by zero - this is not allowed in mathematics
        if (b == 0)
        {
            result = 0.0;
            return false; //* Indicate failure
        }

        //* Perform floating-point division (result can have decimal places)
        result = a / b;
        return true; //* Indicate success
    }
}