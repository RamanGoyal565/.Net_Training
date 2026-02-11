/*
Question No: 1 / 1
Task:
Write a C# program that reads a character from the user and evaluates whether the character is a vowel or not a vowel. The program should use a switch statement to evaluate the input and print the appropriate message.
Requirements:
•	The program should read a single character from the user.
•	The program should evaluate if the entered character is a vowel (a, e, i, o, u, A, E, I, O, U) or not.
•	The program should use a switch statement to perform the evaluation.
•	The program should print a message indicating whether the character is a vowel or not a vowel.
•	Write the solution within the Main function in the Program.cs file.
Input Format:
Input should be given a letter.
Output Format:
The output should be printed whether the letter is a vowel or not a vowel.
Refer Sample Output:
Sample Input 1
a
Sample Output 1
The character 'a' is a vowel.
Sample Input 2
E
Sample Output 2
The character 'E' is a vowel.
Sample Input 3
G
Sample Output 3
The character 'G' is not a vowel.
Commands to Run the Project:
cd dotnetapp
dotnet run
dotnet build
dotnet clean
*/

class Vowel
{
    public void Check()
    {
        char c;
        Console.WriteLine("\n\n--------------------PROGRAM TO CHECK GIVEN CHARACTER IS VOWEL OR NOT-----------------------------");
        Console.Write("Enter a Character ::>> ");
        c = Convert.ToChar(Console.ReadLine()!);

        switch (c)
        {
            case 'a':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'e':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'i':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'o':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'u':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'A':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'E':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'I':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'O':
                Console.WriteLine(c + " is a Vowel");
                break;
            case 'U':
                Console.WriteLine(c + " is a Vowel");
                break;
            default:
                Console.WriteLine(c + " is Not Vowel");
                break;
        }
    }
}