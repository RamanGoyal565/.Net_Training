// class BankAccount
// {
//    public int accNum;
//    private double balance;
//    public BankAccount(int accNum,double balance)
//     {
//         this.accNum=accNum;
//         this.balance=balance;
//         Console.WriteLine(accNum+" "+balance);
//     }
//    public void Deposit(double amount)
//     {
//         balance+=amount;
//         Console.WriteLine("Updated Balance"+balance);
//     } 
// }
// class FixedDeposit : BankAccount
// {
//     int timePeroid;
//     double fdAmn;
//     double rateOfInt;
//     public FixedDeposit():base(101,40000)
//     {
//         Console.Write("Child Constructor");    
//     }
// }
// class Product
// {
//     public string Name;
//     public int Price;

//     public Product()
//     {
//         Console.Write("Default Constructor");
//     }

//     public Product(string name, int price)
//     {
//         Name = name;
//         Price = price;
//         Console.WriteLine("Parameterised Constructor");
//     }
// }

// class Person
// {
//     public string Name;

//     public Person()
//     {
//         Console.WriteLine("Person");
//     }
//     public Person(string name)
//     {
//         Name = name;
//     }
// }

// class Student1 : Person
// {
//     public int RollNo;

//     public Student1( int roll)
//     {
//         RollNo = roll;
//     }
// }