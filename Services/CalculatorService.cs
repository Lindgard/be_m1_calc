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

    public bool PerformCalculation(double num1, string operation, double num2, out double result)
    {
        result = 0.0;

        switch (operation.ToLower())
        {
            case "+":
            case "add":
                result = _calculator.AddNumbers(num1, num2);
                return true;
            case "-":
            case "subtract":
                result = _calculator.SubtractNumbers(num1, num2);
                return true;
            case "*":
            case "multiply":
                result = _calculator.MultiplyNumbers(num1, num2);
                return true;
            case "/":
            case "divide":
                return _calculator.TryDivideNumbers(num1, num2, out result);
            default:
                return false;
        }
    }
}