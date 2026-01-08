//* Service layer - orchestrates between the UI (Program) and business logic (Calculator)
//* Handles input validation, method selection, and error handling
public class CalculatorService
{
    //* Private field to hold the Calculator instance
    //* This is dependency injection - CalculatorService depends on Calculator
    private Calculator _calculator;

    //* Constructor - called when CalculatorService is created
    //* Initializes the Calculator instance
    public CalculatorService()
    {
        _calculator = new Calculator();
    }

    //* Validates and parses user input string to a double number
    //* Returns true if parsing succeeds, false if input is invalid
    //* Uses 'out' parameter to return the parsed number
    public bool TryParseNumber(string? input, out double number)
    {
        //* TryParse is a safe way to convert strings to numbers
        //* It returns false instead of throwing an exception if conversion fails
        return double.TryParse(input, out number);
    }

    //* Performs the calculation based on operation type
    //* Automatically selects integer or double version based on input numbers
    //* Returns false if operation is invalid or division by zero occurs
    //* Returns method type (int/double) via out parameter for testing/debugging
    public bool PerformCalculation(double num1, string operation, double num2, out double result, out string methodType)
    {
        //* Initialize output parameters
        result = 0.0;
        methodType = "";

        //* Determine if we should use integer or double version
        //* Check if both numbers are whole numbers (no decimal part)
        //* num % 1 == 0 means the number has no remainder when divided by 1 (it's a whole number)
        bool useIntVersion = (num1 % 1 == 0) && (num2 % 1 == 0);

        //* Switch statement to handle different operations (case-insensitive)
        switch (operation.ToLower())
        {
            //* Addition operation - supports both "+" and "add" as input
            case "+":
            case "add":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    result = _calculator.AddNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    //* Use double version for decimal numbers
                    result = _calculator.AddNumbers(num1, num2);
                    methodType = "double";
                }
                return true;

            //* Subtraction operation - supports both "-" and "subtract" as input
            case "-":
            case "subtract":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    result = _calculator.SubtractNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    //* Use double version for decimal numbers
                    result = _calculator.SubtractNumbers(num1, num2);
                    methodType = "double";
                }
                return true;

            //* Multiplication operation - supports both "*" and "multiply" as input
            case "*":
            case "multiply":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    result = _calculator.MultiplyNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    //* Use double version for decimal numbers
                    result = _calculator.MultiplyNumbers(num1, num2);
                    methodType = "double";
                }
                return true;

            //* Division operation - supports both "/" and "divide" as input
            case "/":
            case "divide":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    //* TryDivideNumbers returns false if division by zero
                    return _calculator.TryDivideNumbers((int)num1, (int)num2, out result);
                }
                else
                {
                    //* Use double version for decimal numbers
                    //* TryDivideNumbers returns false if division by zero
                    return _calculator.TryDivideNumbers(num1, num2, out result);
                }

            //* Invalid operation - return false to indicate failure
            default:
                return false;
        }
    }
}