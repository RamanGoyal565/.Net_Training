using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HealthSync
{
    public abstract class Consultant
    {
        public string Id { get; set; }
        public double Payout { get; set; }
        public double FinalPayout {  get; set; }
        public string TDS { get; set; } 
        public bool ValidateConsultantId()
        {
            string regex = @"^DR[0-9]{4}";
            return Regex.IsMatch(Id,regex);
        }
        public abstract void CalculateGrossPayout();
        public virtual void CalculateTax()
        {
            CalculateGrossPayout();
            if (Payout > 5000)
            {
                TDS = "5%";
                FinalPayout = Payout - Payout * 5 / 100;
            }
            else
            {
                TDS = "15%";
                FinalPayout = Payout - Payout * 15 / 100;
            }
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Gross: {Payout:F2} | TDS Applied: {TDS} | Net Payout: {FinalPayout:F2}");
        }
    }
    public class InHouse : Consultant
    {
        public double MonthlyStripend { get; set; }
        public override void CalculateGrossPayout()
        {
            Payout = MonthlyStripend + MonthlyStripend * 0.10 + MonthlyStripend * 0.20;
        }

    }
    public class Visiting : Consultant
    {
        public int Visits {  get; set; }
        public double Rate {  get; set; }
        public override void CalculateGrossPayout()
        {
            Payout = Visits*Rate;
        }
        public override void CalculateTax()
        {
            CalculateGrossPayout();
            TDS = "10%";
            FinalPayout = Payout - Payout * 10 / 100;
        }
    }
}
