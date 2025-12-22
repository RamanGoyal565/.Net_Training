abstract class InsurancePolicy
{
    private double premium;
    public string holderName;
    public int PolicyNumber
    {
        get;
        init;
    }
    public double Premium
    {
        get
        {
            return premium;
        }
        set
        {
            if(value>0)
            {
                premium=value;
            }
        }
    }
    public virtual void CalculatePremium(int time)
    {
        premium=premium*time;
    }
    public void Display()
    {
        Console.WriteLine("Insurance Policy");
    }
}

class LifeInsurance : InsurancePolicy
{
    public override void CalculatePremium(int time)
    {
        Premium=Premium*time+500;
        Console.WriteLine("Life Premium: "+Premium);
    }

    public new void Display()
    {
        Console.WriteLine("Life Insurance Policy");
    }
}


class HealthInsurance : InsurancePolicy
{
    public sealed override void CalculatePremium(int time)
    {
        Premium=Premium*time;
        Console.WriteLine("Health Premium: "+Premium);
    }
}