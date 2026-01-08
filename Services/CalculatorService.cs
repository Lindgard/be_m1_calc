public class CalculatorService
{
    private Calculator _calculator;

    public CalculatorService()
    {
        _calculator = new Calculator();
    }

    public bool TryParseNumber(string? input, out double number)
    {
        return double.TryParse(input, out number);
    }

    public bool PerformCalculation(double num1, string operation, double num2, out double result, out string methodType)
    {
        result = 0.0;
        methodType = "";

        bool useIntVersion = (num1 % 1 == 0) && (num2 % 1 == 0);

        switch (operation.ToLower())
        {
            case "+":
            case "add":
                if (useIntVersion)
                {
                    result = _calculator.AddNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    result = _calculator.AddNumbers(num1, num2);
                    methodType = "double";
                }
                return true;
            case "-":
            case "subtract":
                if (useIntVersion)
                {
                    result = _calculator.SubtractNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    result = _calculator.SubtractNumbers(num1, num2);
                    methodType = "double";
                }
                return true;
            case "*":
            case "multiply":
                if (useIntVersion)
                {
                    result = _calculator.MultiplyNumbers((int)num1, (int)num2);
                    methodType = "int";
                }
                else
                {
                    result = _calculator.MultiplyNumbers(num1, num2);
                    methodType = "double";
                }
                return true;
            case "/":
            case "divide":
                if (useIntVersion)
                {
                    return _calculator.TryDivideNumbers((int)num1, (int)num2, out result);
                }
                else
                {
                    return _calculator.TryDivideNumbers(num1, num2, out result);
                }
            default:
                return false;
        }
    }
}