//* Service layer - orchestrates between the UI (Program) and business logic (Calculator)
//* Handles input validation, method selection, and error handling
public class CalculatorService
{
    //* Validates and parses user input string to a double number
    //* Returns true if parsing succeeds, false if input is invalid
    //* Uses 'out' parameter to return the parsed number
    public bool TryParseNumber(string? input, out double number)
    {
        //* TryParse is a safe way to convert strings to numbers
        //* It returns false instead of throwing an exception if conversion fails
        return double.TryParse(input, out number);
    }

    //* Private list of past calculations
    private List<string> _calculationHistory = new List<string>();

    //* Adds a calculation to the history list
    //* If the history list is longer than 3, removes the oldest calculation
    //* Always uses the symbol version of the operation (+, -, *, /) regardless of input
    private void AddToCalculationHistory(double num1, string operation, double num2, double result, string methodType)
    {
        string operationSymbol = GetOperationSymbol(operation);
        string entry = $"{num1} {operationSymbol} {num2} = {result} ({methodType})";
        _calculationHistory.Add(entry);

        if (_calculationHistory.Count > 3)
        {
            _calculationHistory.RemoveAt(0);
        }
    }
    //* Public method to get the calculation history
    public IEnumerable<string> GetCalculationHistory()
    {
        return _calculationHistory;
    }

    //* Private method to get the symbol version of the operation
    private string GetOperationSymbol(string operation)
    {
        switch (operation.ToLower())
        {
            case "add":
            case "+":
                return "+";
            case "subtract":
            case "-":
                return "-";
            case "multiply":
            case "*":
                return "*";
            case "divide":
            case "/":
                return "/";
            default:
                return operation; //* Fallback to original input if not a valid operation
        }
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
                    result = Calculator.AddNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    //* Use double version for decimal numbers
                    result = Calculator.AddNumbers(num1, num2);
                    methodType = "double";
                }

                AddToCalculationHistory(num1, operation, num2, result, methodType);
                return true;

            //* Subtraction operation - supports both "-" and "subtract" as input
            case "-":
            case "subtract":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    result = Calculator.SubtractNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    //* Use double version for decimal numbers
                    result = Calculator.SubtractNumbers(num1, num2);
                    methodType = "double";
                }

                AddToCalculationHistory(num1, operation, num2, result, methodType);
                return true;

            //* Multiplication operation - supports both "*" and "multiply" as input
            case "*":
            case "multiply":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    result = Calculator.MultiplyNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    //* Use double version for decimal numbers
                    result = Calculator.MultiplyNumbers(num1, num2);
                    methodType = "double";
                }

                AddToCalculationHistory(num1, operation, num2, result, methodType);
                return true;

            //* Division operation - supports both "/" and "divide" as input
            case "/":
            case "divide":
                if (useIntVersion)
                {
                    //* Cast doubles to integers and use integer version
                    bool success = Calculator.TryDivideNumbers((int)num1, (int)num2, out result);
                    if (!success)
                    {
                        //* Division by zero, return false and clear methodType, no history entry.
                        methodType = "";
                        return false;
                    }

                    methodType = "int";
                    AddToCalculationHistory(num1, operation, num2, result, methodType);
                    return true;
                }
                else
                {
                    //* Use double version for decimal numbers
                    bool success = Calculator.TryDivideNumbers(num1, num2, out result);
                    if (!success)
                    {
                        //* Division by zero, return false and clear methodType, no history entry.
                        methodType = "";
                        return false;
                    }

                    methodType = "double";
                    AddToCalculationHistory(num1, operation, num2, result, methodType);
                    return true;
                }


            //* Invalid operation - return false to indicate failure
            default:
                return false;
        }
    }
}