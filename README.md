# Intro calculator-project in C# #

Learning basics of C# by creating a calculator CLI with a focus on:

- Method overloading
- While-loop
- Exploring parsing and manipulation of strings
- Separation of concerns (Program, Service, Business Logic layers)

## Pseudokode ##

```txt
START PROGRAM
    CREATE CalculatorService instance
    
    WHILE true (infinite loop)
        // Get first number
        DISPLAY prompt for first number
        READ input1 from console
        
        IF input1 is "exit"
            BREAK loop (exit program)
        END IF
        
        TRY to parse input1 to double using CalculatorService.TryParseNumber()
        IF parsing fails
            DISPLAY error message "Invalid number"
            CONTINUE to next iteration
        END IF
        
        // Get second number
        DISPLAY prompt for second number
        READ input2 from console
        
        IF input2 is "exit"
            BREAK loop (exit program)
        END IF
        
        TRY to parse input2 to double using CalculatorService.TryParseNumber()
        IF parsing fails
            DISPLAY error message "Invalid number"
            CONTINUE to next iteration
        END IF
        
        // Get operator
        DISPLAY prompt for operator (+, -, *, /)
        READ operation from console
        
        IF operation is "exit"
            BREAK loop (exit program)
        END IF
        
        IF operation is empty or null
            DISPLAY error message "Invalid operation"
            CONTINUE to next iteration
        END IF
        
        // Perform calculation through service layer
        CALL CalculatorService.PerformCalculation(num1, operation, num2)
        
        IF calculation succeeds
            DISPLAY result with method type (int or double)
        ELSE
            DISPLAY error message "Invalid operation or division by zero"
        END IF
        
    END WHILE
    
END PROGRAM
```

**CalculatorService pseudocode:**

```txt
CLASS CalculatorService

    // Private list to store calculation history
    PRIVATE calculationHistory : List of string

    // Parse user input into a number
    FUNCTION TryParseNumber(input : string, out number : double)
        RETURN double.TryParse(input, out number)
    END FUNCTION

    // Add calculation to history (max 3 entries)
    PRIVATE FUNCTION AddToCalculationHistory(num1, operation, num2, result, methodType)
        SET operationSymbol = GetOperationSymbol(operation)
        CREATE entry as "num1 operationSymbol num2 = result (methodType)"
        ADD entry to CalculationHistory
    
        IF calculationHistory size > 3
            REMOVE oldest entry
        END IF
    END FUNCTION

    // Return calculation history
    FUNCTION GetCalculationHistory()
        RETURN calculationHistory
    END FUNCTION

    // Convert operation input to symbol form
    PRIVATE FUNCTION GetOperationSymbol(operation)
        SWITCH operation (case-insensitive)
            CASE "add" or "+"
                RETURN "+"
            CASE "subtract" or "-"
                RETURN "-"
            CASE "multiply" or "*"
                RETURN "*"
            CASE "divide" or "/"
                RETURN "/"
            DEFAULT
                RETURN operation
        END SITCH
    END FUNCTION

    //Perform the requested operation
    FUNCTION PerformCalculation(num1, operation, num2)
        INITIALIZE result = 0.0
        INITIALIZE methodType = ""
        
        CHECK if both num1 and num2 are whole numbers (no decimal part)
        IF both are whole numbers
            SET useIntVersion = true
        ELSE
            SET useIntVersion = false
        END IF
        
        SWITCH operation (case-insensitive)
            CASE "+" or "add"
                IF useIntVersion
                    CALL Calculator.AddNumbers(int version) with casted integers
                    SET methodType = "int"
                ELSE
                    CALL Calculator.AddNumbers(double version)
                    SET methodType = "double"
                END IF
                RETURN true with result and methodType
                
            CASE "-" or "subtract"
                IF useIntVersion
                    CALL Calculator.SubtractNumbers(int version) with casted integers
                    SET methodType = "int"
                ELSE
                    CALL Calculator.SubtractNumbers(double version)
                    SET methodType = "double"
                END IF
                RETURN true with result and methodType
                
            CASE "*" or "multiply"
                IF useIntVersion
                    CALL Calculator.MultiplyNumbers(int version) with casted integers
                    SET methodType = "int"
                ELSE
                    CALL Calculator.MultiplyNumbers(double version)
                    SET methodType = "double"
                END IF
                RETURN true with result and methodType
                
            CASE "/" or "divide"
                IF useIntVersion
                    CALL Calculator.TryDivideNumbers(int version) with casted integers
                    IF division by zero
                        RETURN false
                    ELSE
                        SET methodType = "int"
                        RETURN true with result and methodType
                    END IF
                ELSE
                    CALL Calculator.TryDivideNumbers(double version)
                    IF division by zero
                        RETURN false
                    ELSE
                        SET methodType = "double"
                        RETURN true with result and methodType
                    END IF
                END IF
                
            DEFAULT
                RETURN false (invalid operation)
        END SWITCH
    END FUNCTION
```

**Calculator class pseudocode:**

```txt
CLASS Calculator

    // Properties
    PROPERTY Number1 : double
    PROPERTY Number2 : double
    PROPERTY Operation : string
    PROPERTY Result : double
    PROPERTY MethodType : string

    // Constructor
    FUNCTION Calculator(double number1, double number2, string operation)
        SET Number1 = number1
        SET Number2 = number2
        SET Operation = operation
    END FUNCTION

    // Format calculation as a string
    FUNCTION ToString()
        RETURN Number1 + " " + Operation + " " + Number2 + " = " + Result + " (" + MethodType + ")"
    END FUNCTION

    // Integer methods
    FUNCTION AddNumbers(int a, int b)
        RETURN a + b
    END FUNCTION
    
    FUNCTION SubtractNumbers(int a, int b)
        RETURN a - b
    END FUNCTION
    
    FUNCTION MultiplyNumbers(int a, int b)
        RETURN a * b
    END FUNCTION
    
    FUNCTION TryDivideNumbers(int a, int b, out int result)
        IF b equals 0
            SET result = 0
            RETURN false
        ELSE
            SET result = a / b
            RETURN true
        END IF
    END FUNCTION
    
    // Double methods (method overloading)
    FUNCTION AddNumbers(double a, double b)
        RETURN a + b
    END FUNCTION
    
    FUNCTION SubtractNumbers(double a, double b)
        RETURN a - b
    END FUNCTION
    
    FUNCTION MultiplyNumbers(double a, double b)
        RETURN a * b
    END FUNCTION
    
    FUNCTION TryDivideNumbers(double a, double b, out double result)
        IF b equals 0
            SET result = 0.0
            RETURN false
        ELSE
            SET result = a / b
            RETURN true
        END IF
    END FUNCTION
END CLASS
```
