using System.Security.Principal;

// class BankAccount
// {
//    public int accNum;
//    private double balance;
//    public void Deposit(double amount)
//     {
//         balance+=amount;
//         Console.WriteLine("Updated Balance"+balance);
//     } 
// }
// BankAccount acc1=new BankAccount();
// acc1.accNum=101;
// acc1.balance=10000;
class Employee
{
    public String name;
    public double salary;
    public void DisplayDetails()
    {
        Console.WriteLine(name+"earns"+salary);
    }   
}
// Employee emp1=new Employee();
// emp1.name="Raman Goyal";
// emp1.salary=23000;
// emp1.DisplayDetails();
class Wallet
{
    private double money;
    public void AddMoney(double amt)
    {
        money+=amt;
    }
    public double GetBalancle()
    {
        return money;
    }
}

class Math1
{
    public static int Add(int num1,int num2)
    {
        return num1+num2;
    } 
    // public static int Add(int num1,int num2,int num3)
    // {
    //     return num1+num2+num3;
    // }
    public double Add(double num1,double num2)
    {
        return num1+num2;
    }
}


class ForEach
{
    public void Display()
    {
        string name="Raman Goyal";
        foreach(char ch in name)
        {
            Console.WriteLine(ch);
        }
    }
    public int Sum(char a='a',params int[] num)
    {
        int total=0;
        // double sum=0.0;
        foreach(int i in num)
        {
            total+=i;
        }
        // foreach(double i in arr)
        // {
        //     sum+=i;
        // }
        // Console.Write(sum);
        return total+a;
    }
}

class RefOutIn
{
    public int x=10;
    public void IncByTen(ref int a)
    {
        a=a+10;
    }
}