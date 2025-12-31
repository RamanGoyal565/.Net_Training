using System.Text.RegularExpressions;
namespace LogProcessing
{
    class LogParser
    {
        readonly private string validLineRegexPattern=@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        readonly private string splitLineRegexPattern=@"<[*=\^]+>";
        readonly private string quotedPasswordRegexPattern=@"""[^""]*password[^""]*""";
        readonly private string endOfLineRegexPattern=@"end-of-line[\d]+$";
        readonly private string weakPasswordRegexPattern=@"\bpassword[\w]+\b";

        public bool IsValidLine(string text)
        {
            if(Regex.IsMatch(text,validLineRegexPattern))
            return true;
            return false;
        }
        public string[] SplitLogLine(string text)
        {
            return Regex.Split(text,splitLineRegexPattern);
        }
        public int CountQuotedPasswords(string lines)
        {
            return Regex.Matches(lines,quotedPasswordRegexPattern).Count;
        }
        public string RemoveEndOfLineText(string line)
        {
            return Regex.Replace(line,endOfLineRegexPattern,"");
        }
        public string[] ListLinesWithPasswords(string[] lines)
        {
            string[] ans=new string[lines.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                if(Regex.IsMatch(lines[i],weakPasswordRegexPattern))
                {
                    ans[i]=Regex.Match(lines[i],weakPasswordRegexPattern).Value+": "+lines[i];
                }
                else
                ans[i]="--------: "+lines[i];
            }
            return ans;
        }
        public void main()
        {
            LogParser obj=new LogParser();
            Console.WriteLine("[INF] Application started \n"+obj.IsValidLine("[INF] Application started"));
            Console.WriteLine("[ERR] Database connection failed \n"+obj.IsValidLine("[ERR] Database connection failed"));
            Console.WriteLine("[WRN] Low memory warning \n"+obj.IsValidLine("[WRN] Low memory warning"));
            Console.WriteLine("INF Application started \n"+obj.IsValidLine("INF Application started"));
            Console.WriteLine("[INFO] Application started \n"+obj.IsValidLine("[INFO] Application started"));
            
            Console.WriteLine("[INF] User login<***>Session created<====>Access granted");
            string[] task2=obj.SplitLogLine("[INF] User login<***>Session created<====>Access granted");
            foreach(string i in task2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("User said \"password123 is weak\"\nAdmin noted \"PASSWORD456 expired\"\nNo issue found");
            Console.WriteLine(obj.CountQuotedPasswords("User said \"password123 is weak\"\nAdmin noted \"PASSWORD456 expired\"\nNo issue found"));

            Console.WriteLine("Transaction completed successfully end-of-line456");
            Console.WriteLine(RemoveEndOfLineText("Transaction completed successfully end-of-line456"));

            string[] lines={
                "User entered password123 during login",
                "System startup completed",
                "Admin reset passwordABC",
                "Backup process finished"
            };
            string[] task5=ListLinesWithPasswords(lines);
            foreach(string i in task5)
            {
                Console.WriteLine(i);    
            }
        }
    }
}