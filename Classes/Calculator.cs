//* Model class - contains the business logic for the calculator

public class Calculator
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public string Operation { get; set; }
    public double Result { get; set; }
    public string MethodType { get; set; }

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
}