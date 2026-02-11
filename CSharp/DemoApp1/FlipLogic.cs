// This method takes a word as input and performs a series of transformations and return a customized format of string. The transformation logic includes:
// 1) The input must not be null, and it must contain at least 6 characters long. If it is shorter or null, the function should return an empty string.
// 2)The input must not contain any space, digit or special characters. If not, the function should return an empty string.
// Password Generation Logic:
// •	Convert the input to lowercase.
// •	Remove all characters whose ASCII values are even numbers.
// •	Reverse the remaining characters.
// •	In the reversed string, convert characters that have even positioned character (0 based index) to uppercase. Refer to the sample input and output.
// Return the generated key. 


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

class FlipLogic
{
    public string CleanseAndInvert(string input)
    {
        if(string.IsNullOrEmpty(input)||input.Length<6)
        {
            return "";
        }
        if(!input.All(char.IsLetter))
        {
            return "";
        }
        string ans="";
        input=input.ToLower();
        for(int i=input.Length-1;i>=0;i--)
        {
           if(input[i]%2==0)
           continue;
           ans+=(char)input[i]; 
        }
        string finalAns=""; 
        for(int i=0;i<ans.Length;i++)
        {
            if(i%2==0)
            finalAns+=(char)(ans[i]-32);
            else
            finalAns+=ans[i];
        }
        return finalAns;
    }
}