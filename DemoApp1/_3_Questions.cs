/*
1)Sample C# program to print a welcome message
2)Write C# program to read a number user and display it
3)Write C# program to read a floating point number from user 
4)Write C# program to read a string from user and display it on the screen 
5)Write C# program to perform all arithmetic operations
6)Write C# program to find the area of circle 
7) program to find whether the given number is Even or Odd 
8)program to find the greatest of 2 numbers 
9) program to find whether a given number is positive ,negative or zero
10 program to find the greatest of three numbers using nested if
*/

class Questions
{
    public void Ques()
    {
        // 1)Sample C# program to print a welcome message
        Console.WriteLine("\n\nQ1 Sample C# program to print a welcome message");
        Console.WriteLine("WELCOME TO THE DOTNET PROGRAMMING");





        // 2)Write C# program to read a number user and display it
        Console.WriteLine("\n\nQ2 Write C# program to read a number user and display it");
        int num = 0;

        Console.Write("Enter a Number ::>> ");
        num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("You have entered a number that is " + num);





        // Q3 Write C# program to read a floating point number from user
        Console.WriteLine("\n\nQ3 Write C# program to read a floating point number from user");
        float floatNum = 0.0f;

        Console.Write("Enter Floating Number ::>> ");
        floatNum = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine("Float number is " + floatNum);





        // Q4 Write C# program to read a string from user and display it on the screen
        Console.WriteLine("\n\nQ4 Write C# program to read a string from user and display it on the screen");
        string Name = string.Empty;

        Console.Write("Enter you Name ::>> ");
        Name = Console.ReadLine()!;

        Console.WriteLine("Name is " + Name);





        // Q5 Write C# program to perform all arthmetic operations
        Console.WriteLine("\n\nQ5 Write C# program to perform all arthmetic operations");
        int num1 = 0;
        int num2 = 0;
        int result = 0;

        Console.Write("Enter the first number for sum ::>> ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number for sum ::>> ");
        num2 = Convert.ToInt32(Console.ReadLine());

        result = num1 + num2;
        Console.WriteLine("Sum of both number is ::>> " + result);





        // Q6 Write C# program to find the area of circle
        Console.WriteLine("\n\nQ6 Write C# program to find the area of circle");
        float area = 0.0f;
        int r = 0;

        Console.Write("Enter radius of a circle ::>> ");
        r = Convert.ToInt32(Console.ReadLine());

        area = Convert.ToSingle(3.14 * r * r);
        Console.WriteLine("Area of the circle is ::>> " + area);





        // Q7 Program to find whether the given numer is EVEN or ODD
        Console.WriteLine("\n\nQ7 Program to find whether the given numer is EVEN or ODD");
        int evenOddNum = -1;

        Console.Write("Enter a number to check EVEN or ODD ::>> ");
        evenOddNum = Convert.ToInt32(Console.ReadLine());

        if (evenOddNum % 2 == 0)
        {
            Console.WriteLine("Entered number is EVEN");
        }
        else
        {
            Console.WriteLine("Entered number is ODD");
        }





        // Q8 Program to find greatest of 2 number
        Console.WriteLine("\n\nQ8 Program to find greatest of 2 number");
        float floatNum1 = 0.0f;
        float floatNum2 = 0.0f;

        Console.Write("Enter the first number ::>> ");
        floatNum1 = Convert.ToSingle(Console.ReadLine());

        Console.Write("Enter the second number ::>> ");
        floatNum2 = Convert.ToSingle(Console.ReadLine());

        if (floatNum1 > floatNum2)
        {
            Console.WriteLine("Number 1 is great that is " + floatNum1);
        }
        else
        {
            Console.WriteLine("Number 2 is great that is " + floatNum2);
        }





        // 9) program to find whether a given number is positive ,negative or zero
        Console.WriteLine("\n\nQ9 program to find whether a given number is positive ,negative or zero");
        int PosNegNum = 0;

        Console.Write("Enter the first number ::>> ");
        PosNegNum = Convert.ToInt32(Console.ReadLine());

        if (PosNegNum > 0)
        {
            Console.WriteLine("number is POSITIVE");
        }
        else if (PosNegNum < 0)
        {
            Console.WriteLine("number is NEGATIVE");
        }
        else
        {
            Console.WriteLine("number is ZERO");
        }





        // 10 program to find the greatest of three numbers using nested if*/
        Console.WriteLine("\n\n10 program to find the greatest of three numbers using nested if");
        int threeNum1 = 0;
        int threeNum2 = 0;
        int threeNum3 = 0;

        Console.Write("Enter the first number ::>> ");
        threeNum1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number ::>> ");
        threeNum2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the thord number ::>> ");
        threeNum3 = Convert.ToInt32(Console.ReadLine());

        if (threeNum1 > threeNum2)
        {
            if (threeNum1 > threeNum3)
            {
                Console.WriteLine("Number 1 is greater that is " + threeNum1);
            }
            else
            {
                Console.WriteLine("Number 3 is greater that is " + threeNum3);
            }
        }
        else
        {
            if (threeNum2 > threeNum3)
            {
                Console.WriteLine("Number 2 is greater that is " + threeNum2);
            }
            else
            {
                Console.WriteLine("Number 3 is greater that is " + threeNum3);
            }
        }





        // 11 program to find the greatest of three numbers using and
        Console.WriteLine("\n\n11 program to find the greatest of three numbers using and");
        int threeAndNum1 = 0;
        int threeAndNum2 = 0;
        int threeAndNum3 = 0;

        Console.Write("Enter the first number ::>> ");
        threeAndNum1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number ::>> ");
        threeAndNum2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the thord number ::>> ");
        threeAndNum3 = Convert.ToInt32(Console.ReadLine());

        if (threeAndNum1 > threeAndNum2 && threeAndNum1 > threeAndNum3)
        {
            Console.WriteLine("Number 1 is greate that is " + threeAndNum1);
        }
        else if (threeAndNum2 > threeAndNum3)
        {
            Console.WriteLine("Number 2 is greater that is " + threeAndNum2);
        }
        else
        {
            Console.WriteLine("Number 3 is greater that is " + threeAndNum3);
        }
    }

}