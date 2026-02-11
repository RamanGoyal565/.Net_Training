// See https://aka.ms/new-console-template for more information
using System.Security.Permissions;

class Program
{
    public static void Main(string[] args)
    {
        Security sec=new Security();
        sec.Password="ghghgh";
        sec.Authenticate("ghghgh");


        InsurancePolicy ins1=new LifeInsurance();
        LifeInsurance life1=new LifeInsurance()
        {
            PolicyNumber=101
        };
        HealthInsurance health1=new HealthInsurance()
        {
            PolicyNumber=102
        };
        life1.holderName="Raman Goyal";
        life1.Premium=1000;
        health1.holderName="Sandeep Kumar";
        health1.Premium=1500;


        PolicyDirectory policy=new PolicyDirectory();
        policy[life1.PolicyNumber]=life1.holderName;
        policy[health1.PolicyNumber]=health1.holderName;

        Console.WriteLine(policy[life1.PolicyNumber]);
        Console.WriteLine(policy[health1.holderName]);

        life1.CalculatePremium(5);
        health1.CalculatePremium(5);
        life1.Display();
        ins1.Display();
    }
}