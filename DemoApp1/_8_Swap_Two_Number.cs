/*
Extracted Text from Image
Question No: 1 / 1
Task

Write a C# program that reads two integer values from the user, swaps their values without using a temporary variable, and then prints the swapped values.

Requirements

The program should read two integers from the user.
The program should then swap the values of these integers using arithmetic operations (without the help of any additional variables).
Finally, the program should print the values of the integers before and after the swap.
Write the solution within the Main function in the Program.cs file.

Input Format
The first line of input is the integer
The second line of input is the integer

Output Format
First line of output contains before swapping the integers.
Second line of output contains after swapping the integers.

Sample Input 1
1
2
Sample Output 1
Before swap: a = 1, b = 2
After swap: a = 2, b = 1

Sample Input 2
56
65
Sample Output 2
Before swap: a = 56, b = 65
After swap: a = 65, b = 56
*/

class SwapTwoNumber
{
    public void swap()
    {
        int num1;
        int num2;

        Console.Write("Enter first num ::>> ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second num ::>> ");
        num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Before Swap a is {num1} and b is {num2}");

        num1 = num1 + num2;  // 7
        num2 = num1 - num2;  // 7 - 4 = 3
        num1 = num1 - num2;  // 7 - 3 = 4
        Console.WriteLine($"After Swap a is {num1} and b is {num2}");
    }
}