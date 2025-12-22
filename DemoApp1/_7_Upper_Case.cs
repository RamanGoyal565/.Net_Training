/*
=================================================================
Question No : 1 / 3
Task:
Write a C# program that reads a string from the user, converts it to uppercase, and prints the length of the original string and the uppercase string.
Requirements:
•	The program should read a string from the user.
•	The program should convert the string to uppercase.
•	The program should determine the length of the original string.
•	The program should print the length of the original string and the uppercase string.
•	Write the solution within the Main function in the Program.cs file.
Input Format:
The first line of input will be string.
Output Format:
The first line of output will be the length of input string.
The second line of output will be the converted uppercase string.
Refer Sample Output:
Sample Input:
Demo
Sample Output:
Original string length: 4
Uppercase string: DEMO
Commands to Run the Project:
•	cd dotnetapp
Select the dotnet project folder
•	dotnet run
To run the application
•	dotnet build
To build and check for errors
•	dotnet clean
If the same error persists clean the project and build again
________________________________________
*/

class ConvUpPrint
{
    public void ConvertUpperPrint()
    {
        string str = string.Empty;
        int length = 0;
        Console.Write("Enter a String ::>> ");
        str = Console.ReadLine()!;

        length = str.Length;
        str = str.ToUpper();

        Console.WriteLine($"The length of the String is {length} and Converted to upper case is {str}");

    }
}