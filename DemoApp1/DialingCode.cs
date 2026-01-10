namespace DialingCodes
{
    class DialingCodes
    {
        public static Dictionary<int,string> GetEmptyDictionary()
        {
            return new Dictionary<int,string>();
        }
        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>
            {
                {1,"United States of America"},
                {55,"Brazil"},
                {91,"India" }
            };
        }
        public static Dictionary<int,string> AddCountryToEmptyDictionary(int countryCode,string countryName)
        {
            return new Dictionary<int, string>
            {{countryCode,countryName}};
        }
        public static Dictionary<int,string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            existingDictionary.Add(countryCode,countryName);
            return existingDictionary;    
        }
        public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int countryCode)
        {
            if(CheckCodeExists(existingDictionary,countryCode))
            return existingDictionary[countryCode];
            return "";
        }
        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }
        public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            if (CheckCodeExists(existingDictionary, countryCode))
            {
                existingDictionary[countryCode]=countryName;
            }
            return existingDictionary;
        }
        public static Dictionary<int,string> RemoveCountryFromDictionary(Dictionary<int,string> existingDictionary,int countryCode)
        {
            existingDictionary.Remove(countryCode);
            return existingDictionary;
        }
        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            string ans="";
            foreach(string i in existingDictionary.Values)
            {
                if(ans.Length<i.Length)
                ans=i;
            }
            return ans;
        }
        public static void PrintDictionary(in Dictionary<int,string> dictionary)
        {
            foreach(var i in dictionary)
            {
                Console.WriteLine($"Code: {i.Key}, Country: {i.Value}");
            }
        }
    }
    class Program
    {
        public static void main()
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
}