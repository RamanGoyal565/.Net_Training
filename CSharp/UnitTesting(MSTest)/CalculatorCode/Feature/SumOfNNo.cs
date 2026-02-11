using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorCode.Feature
{
    public class SumOfNNo
    {
        public int Sum(int n)
        {
            if (n < 0)
                throw new Exception("Invalid Input");
            return n * (n + 1) / 2;
        }
    }
}
