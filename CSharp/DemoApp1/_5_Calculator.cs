class Calculator
{
    int num1;
    int num2;
    int result;

    public Calculator()
    {
        Console.WriteLine("\n\n\t\t-----------------------------------WELCOME TO CALCULATOR APP----------------------");
    }

    private void takeInput()
    {
        Console.Write("Enter first num ::>> ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second num ::>> ");
        num2 = Convert.ToInt32(Console.ReadLine());
    }
    public void Add()
    {
        Console.WriteLine("\n+++++++++++++++-----SUM------+++++++++++++++++++++");
        takeInput();
        result = num1 + num2;
        Console.WriteLine($"Sum of numbers is {result}");
        Console.WriteLine("+++++++++++++++++-----DONE------+++++++++++++++++++\n\n");

    }

    public void Subtract()
    {
        Console.WriteLine("\n++++++++++++++-----SUBTRACT-------++++++++++++++++");
        takeInput();
        result = num1 - num2;
        Console.WriteLine($"Subtraction of numbers is {result}");
        Console.WriteLine("+++++++++++++++++-----DONE------+++++++++++++++++++\n\n");

    }

    public void Multiply()
    {
        Console.WriteLine("\n++++++++++++++-----MULTIPLY-------++++++++++++++++");
        takeInput();
        result = num1 * num2;
        Console.WriteLine($"Multiply of numbers is {result}");
        Console.WriteLine("+++++++++++++++++-----DONE------+++++++++++++++++++\n\n");

    }

    public void Divide()
    {
        Console.WriteLine("\n++++++++++++++-----DIVISION-------++++++++++++++++");
        takeInput();
        result = num1 / num2;
        Console.WriteLine($"Division of numbers is {result}");
        Console.WriteLine("+++++++++++++++++-----DONE------+++++++++++++++++++\n\n");

    }

    public void Remainder()
    {
        Console.WriteLine("\n++++++++++++++-----REMAINDER-------++++++++++++++++");
        takeInput();
        result = num1 % num2;
        Console.WriteLine($"Remainder of numbers is {result}");
        Console.WriteLine("+++++++++++++++++-----DONE------+++++++++++++++++++\n\n");

    }
}