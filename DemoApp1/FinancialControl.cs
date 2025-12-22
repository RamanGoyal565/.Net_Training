// Loan Eligibility Rules
// Age must be 21 years or above
// Monthly income must be ₹30,000 or more

// Income Tax Rules
// Annual Income
// Tax Rate
// ≤ ₹2,50,000
// 0%
// ₹2,50,001 – ₹5,00,000
// 5%
// ₹5,00,001 – ₹10,00,000
// 20%
// Above ₹10,00,000
// 30%

// Transaction Rules
// User can enter 5 transactions
// Negative amount is invalid
// Invalid transactions should be skipped

// Menu Design (Using switch-case)
// 1. Check Loan Eligibility
// 2. Calculate Tax
// 3. Enter Transactions
// 4. Exit
class FinancialControlSystem
{
    void LoanEligibility()
    {
        int age;
        int salary;
        Console.WriteLine("Enter your age:");
        age=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your Salary:");
        salary=Convert.ToInt32(Console.ReadLine());
        float EMI=Convert.ToSingle(Console.ReadLine());
        if (age >= 21 && salary >= 30000 && EMI <= 0.4 * salary)
        {           
            Console.WriteLine("Eligible for Loan");
        }
        else
        {
            Console.WriteLine("Not Eligible");
        }
    }
    void IncomeTaxCalc()
    {
        int salary;
        int annualIncome;
        int tax;
        Console.WriteLine("Enter your Salary:");
        salary=Convert.ToInt32(Console.ReadLine());
        annualIncome=salary*12;
        if (annualIncome <= 250000)
        {
            tax=0;
        }
        else if (annualIncome <= 500000)
        {
            tax=(annualIncome-250000)*5/100;
        }
        else if (annualIncome <= 1000000)
        {
            tax=250000*5/100+(annualIncome-500000)*20/100;
        }
        else
        {
            tax=250000*5/100+500000*20/100+(annualIncome-1000000)*30/100;
        }
        Console.WriteLine("Your Income tax amount is : {0}",tax);
    }
    void TransactionEntrySystem()
    {
        float currentBaln;
        Console.WriteLine("Enter your CurrentBalance:");
        currentBaln=Convert.ToSingle(Console.ReadLine());
        Console.WriteLine("Enter number of transactions");
        int numTranc=Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < numTranc; i++)
        {
            float transaction=Convert.ToSingle(Console.ReadLine());
            if(transaction<0)
            {
                Console.WriteLine("Invalid Teansaction");
                Console.WriteLine("Skiping this Transaction");
            }
            else
            {
                currentBaln+=transaction;
            }
        }
        Console.WriteLine("Balance after transactions : {0}",currentBaln);
    }
    public void ControlSystem()
    {
        int choice;
        FinancialControlSystem obj=new FinancialControlSystem();
        do
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Check Loan Eligibility");
            Console.WriteLine("2. Calculate Tax");
            Console.WriteLine("3. Enter Transactions");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter Choice");
            choice=Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                obj.LoanEligibility();
                break;
                case 2:
                obj.IncomeTaxCalc();
                break;
                case 3:
                obj.TransactionEntrySystem();
                break;
                case 4:
                Console.WriteLine("Exiting");
                break;
                default:
                Console.WriteLine("Invalid Choice");
                break;
            }
        }
        while(choice!=4);
    }
}