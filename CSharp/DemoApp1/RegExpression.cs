using System.Text.RegularExpressions;
class RegExpression
{
    public void func1()
    {
        // string sentence="abc123";
        string pattern=@"\p{L}";
        // string sentence="123_123";
        string sentence = "Hello?10A20B30C!@_abc _0!\tC:\abc\file.txt?Hello";
        // string pattern=@"\d+";
        // string pattern1 = @"Hello$";
        bool result=Regex.IsMatch(sentence,pattern);
        Match m=Regex.Match(sentence,pattern);
        Console.WriteLine(result);
        Console.WriteLine(m.Value);

        // MatchCollection m=Regex.Matches(sentence,pattern);
        // Console.WriteLine(m); 
        // pattern=@"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})";
        // sentence="2025-12-30";
        // Match m1=Regex.Match(sentence,pattern);
        // Console.WriteLine(m1.Groups["year"].Value);
        // Console.WriteLine(m1.Groups["month"].Value);
        // sentence="2025-12-30,2004-03-03";
        // MatchCollection matches=Regex.Matches(sentence,pattern);
        // foreach(Match i in matches){
        //     Console.WriteLine(i.Groups["year"].Value);
        //     Console.WriteLine(i.Groups["month"].Value);
        // }
        // MatchCollection m = Regex.Matches("grapple apples a123e", @"a...e");
        // foreach (Match i in m)
            // Console.WriteLine(i.Value);
        // List<string> Emails = new List<string>
        // {
        //     "john.doe@gmail.com",
        //     "alice_123@yahoo.in",
        //     "mark.smith@company.com",
        //     "support-abc@banking.co.in",
        //     "user.nametag@domain.org",
        //     "john.doe@gmail",          // Missing domain extension
        //     "alice@@yahoo.com",        // Double @
        //     "mark.smith@.com",         // Domain missing name
        //     "support@banking..com",    // Double dot in domain
        //     "user name@gmail.com",     // Space not allowed
        //     "@domain.com",             // Missing username
        //     "admin@domain",            // No top-level domain
        //     "info@domain,com",         // Comma instead of dot
        //     "finance#dept@corp.com",   // Invalid character #
        //     "plainaddress"             // Missing @ and domain

        // };
        // string pattern=@"^[\w.-]+@[\w-]+(\.[\w]{2,})+$";
        // foreach(string input in Emails)
        // {
        //     if (Regex.IsMatch(input, pattern))
        //     {
        //         Console.WriteLine(input+" is valid");
        //     }
        //     else
        //         Console.WriteLine(input+" is not valid");
        // }
    }
}