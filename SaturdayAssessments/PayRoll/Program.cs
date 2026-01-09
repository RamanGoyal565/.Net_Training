class Program
{
    public static List<EmployeeRecord> PayRollBoard;
    public void RegistraterEmployee(EmployeeRecord record)
    {
        record.Registration();
        PayRollBoard.Add(record);
    }
    public Dictionary<string,int> GetOvertimeWeeklyCounts(List<EmployeeRecord> records,double hoursThreshold)
    {
        Dictionary<string,int> dic=new Dictionary<string, int>();
        foreach(EmployeeRecord i in records)
        {
            int qualifingWeeks=0;
            foreach(double j in i.WeeklyHours)
            {
                if(j>=hoursThreshold)
                {
                   qualifingWeeks++;
                }
            }
            if(qualifingWeeks>0)
            {
                dic.Add(i.EmployeeName,qualifingWeeks);
            }
        }
        return dic;
    }

    public double CalculateAverageMonthlyPay()
    {
        if(PayRollBoard.Count==0)
        return 0;
        double total=0;
        foreach(EmployeeRecord i in PayRollBoard)
        {
            total+=i.GetMonthlyPay();
        }
        return total/PayRollBoard.Count;
    }
    public void Menu()
    {
        Console.WriteLine("1. Register Employee");
        Console.WriteLine("2. Show Overtime Summary");
        Console.WriteLine("3. Calculate Average Monthly Pay");
        Console.WriteLine("4. Exit");
    }
    public static void Main(String[] args)
    {
        PayRollBoard = new List<EmployeeRecord>();
        Program obj=new Program();
        int choice=0;
        do
        {
            obj.Menu();
            Console.WriteLine("Enter tour choice:");
            choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                int choice2=Convert.ToInt16(Console.ReadLine());

                if(choice2>2)
                {
                    Console.WriteLine("Invalid choice");
                }
                else if(choice2==1)
                {
                    EmployeeRecord fullTime=new FullTimeEmployee();
                    obj.RegistraterEmployee(fullTime);     
                }
                else
                {
                    EmployeeRecord contract=new ContractEmployee();
                    obj.RegistraterEmployee(contract);     
                }            
                Console.WriteLine("\n---\n");
                break;
                case 2:
                Console.WriteLine("Enter hours threshold:");
                double hoursThreshold=Convert.ToDouble(Console.ReadLine());
                Dictionary<string,int> dic=obj.GetOvertimeWeeklyCounts(PayRollBoard,hoursThreshold);
                if(dic.Count==0)
                {
                    Console.WriteLine("No overtime recorded this month");
                }
                else
                {
                    foreach(string i in dic.Keys)
                    {
                        Console.WriteLine(i+" - "+dic[i]);        
                    }                    
                }
                Console.WriteLine("\n---\n");
                break;
                case 3:
                Console.WriteLine("Overall average monthly pay: "+obj.CalculateAverageMonthlyPay());
                Console.WriteLine("\n---\n");
                break;
                case 4:
                Console.WriteLine("Logging off — Payroll processed successfully!");
                break;
                default:
                Console.WriteLine("Invalid Choice");
                break;
            }            
        }
        while(choice!=4);
    }
}