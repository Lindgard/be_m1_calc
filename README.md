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

**CalculatorService.PerformCalculation() pseudocode:**

```txt
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
