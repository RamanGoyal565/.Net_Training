abstract class EmployeeRecord
{
    public string EmployeeName
    {
        get;
        set;
    }
    public double[] WeeklyHours
    {
        get;
        set;
    }=new double[4];
    public abstract double GetMonthlyPay();
    public abstract void Registration();
}

class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate
    {
        get;
        set;
    }
    public double MonthlyBonus
    {
        get;
        set;
    }
    public override double GetMonthlyPay()
    {
        double hours=0;
        foreach(double i in WeeklyHours)
        {
            hours+=i;
        }
        return hours*HourlyRate+MonthlyBonus;
    }
    public override void Registration()
    {
        Console.WriteLine("Enter Employee Name:");
        EmployeeName=Console.ReadLine();
        Console.WriteLine("Enter Hourly Rate:");
        HourlyRate=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Monthly Bonus:");
        MonthlyBonus=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
        for(int i = 0; i < 4; i++)
        {
            WeeklyHours[i]=Convert.ToDouble(Console.ReadLine());
        }
    }
}
class ContractEmployee : EmployeeRecord
{
    public double HourlyRate
    {
        get;
        set;
    }
    public override double GetMonthlyPay()
    {
        double hours=0;
        foreach(double i in WeeklyHours)
        {
            hours+=i;
        }
        return hours*HourlyRate;
    }
    public override void Registration()
    {
        Console.WriteLine("Enter Employee Name:");
        EmployeeName=Console.ReadLine();
        Console.WriteLine("Enter Hourly Rate:");
        HourlyRate=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
        for(int i = 0; i < 4; i++)
        {
            WeeklyHours[i]=Convert.ToDouble(Console.ReadLine());
        }
    }
}