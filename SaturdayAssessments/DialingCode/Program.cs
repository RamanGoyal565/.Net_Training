using DialingCodeApp;
using System;
class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int,string> emptDict=DialingCodes.GetEmptyDictionary();
        Console.WriteLine(emptDict.Count);
        
        Dictionary<int,string> existingDict=DialingCodes.GetExistingDictionary();
        DialingCodes.PrintDictionary(existingDict);
        
        Dictionary<int,string> SingleEntryDict=DialingCodes.AddCountryToEmptyDictionary(81,"Japan");
        DialingCodes.PrintDictionary(SingleEntryDict);
        
        existingDict=DialingCodes.AddCountryToExistingDictionary(existingDict,44,"United Kingdom");
        DialingCodes.PrintDictionary(existingDict);
        
        Console.WriteLine(DialingCodes.GetCountryNameFromDictionary(existingDict,91));
        
        Console.WriteLine(DialingCodes.CheckCodeExists(existingDict,91));
        
        existingDict=DialingCodes.UpdateDictionary(existingDict,55,"Federative Republic of Brazil");
        DialingCodes.PrintDictionary(existingDict);
        
        existingDict=DialingCodes.RemoveCountryFromDictionary(existingDict,1);
        DialingCodes.PrintDictionary(existingDict);
        
        Console.WriteLine(DialingCodes.FindLongestCountryName(existingDict));
        
    }
}