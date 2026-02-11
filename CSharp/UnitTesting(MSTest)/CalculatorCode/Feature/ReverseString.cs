using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace CalculatorCode.Feature
{
    public class ReverseString
    {
        public string Reverse(string str)
        {
            string ans = "";
            for(int i=str.Length-1; i>=0;i--)
                ans += str[i];
            return ans;
        }
    }
}
