using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        //2-Data Types
        // Data_Types dt = new Data_Types();
        // dt.PrintAll();

        //3-QUESTION
        // Questions q = new Questions();
        // q.Ques();

        //4-Employee
        // Employee emp1 = new Employee();
        // // emp1.AcceptDetails(1,"Sandeep","CSE",2000.45f,'M');
        // Console.WriteLine("\n\n");
        // emp1.AcceptDetails();
        // Console.WriteLine("\n");
        // emp1.DisplayDetails();
        // Console.WriteLine("\n");

        //5-CALCULATOR APP
        // Calculator cal = new Calculator();
        // cal.Add();
        // cal.Subtract();
        // cal.Multiply();
        // cal.Divide();
        // cal.Remainder();

        //6-Check_Vowel
        // Vowel vowObj = new Vowel();
        // vowObj.Check();

        //7-Convert-to-uppercase-and-find-length-and-print
        // ConvUpPrint cupObj = new ConvUpPrint();
        // cupObj.ConvertUpperPrint(); 

        // 8-Swap-two-number-without-using-third-variable
        // SwapTwoNumber swapObj = new SwapTwoNumber();
        // swapObj.swap();

        // 9-Sum-of-5-number
        // SumOfNumberWhile sumWhileObj = new SumOfNumberWhile();
        // sumWhileObj.sum();

        // 10-Do-while-Example
        // DoWhileExample doWhileObj = new DoWhileExample();
        // doWhileObj.Example1();

        // TableUsingForLoop
        // TableUsingForLoop table = new TableUsingForLoop();
        // table.PrintTable();

        // ContinueStatement
        // ContinueStatement continueStatement = new ContinueStatement();
        // continueStatement.Game();

        // BIFS System
        // FinancialControlSystem financialObj=new FinancialControlSystem();
        // financialObj.ControlSystem();

        //new DebitCredit().MainMenu();

        // BankAccount acc1=new BankAccount();
        // acc1.accNum=101;
        // acc1.balance=10000;

        // Employee emp1=new Employee();
        // emp1.name="Raman Goyal";
        // emp1.salary=23000;
        // emp1.DisplayDetails();

        // Wallet wlt1=new Wallet();
        // wlt1.AddMoney(1009.9898);
        // Console.WriteLine("Balance in Wallet ="+wlt1.GetBalancle());

        // Console.WriteLine(Math.Add(12,34));
        // //Console.WriteLine(Math.Add(12,34,56));
        // Console.WriteLine(new Math().Add(12.56,34.64));
        // Console.WriteLine(new Math().Add(22.3,45));


        // ForEach obj1=new ForEach();
        // obj1.Display();
        // Console.Write(obj1.Sum('1',2,4,5,7));

        // RefOutIn obj=new RefOutIn();
        // obj.IncByTen(ref obj.x);
        // Console.Write(obj.x);


        // BankAccount acc1=new BankAccount(101,40000);

        // FixedDeposit fd1=new FixedDeposit();

        // Product p = new Product
        // {
        //     Name = "Laptop",
        //     Price = 50000
        // };

        // Student stu1=new Student(12216883)
        // {
        //     AdmissionYear=2022
        // };
        // stu1.Name="Raman Goyal";
        // stu1.Age=21;
        // stu1.Marks=45;
        // stu1.Password="jubvdbdukv";
        // stu1.StudentID=12039;
        // Console.WriteLine($"Student ID is equal to {stu1.StudentID} result is {stu1.Result}");
        // Console.WriteLine($"Name is {stu1.Name} age is {stu1.Age} marks is {stu1.Marks}");
        // Console.WriteLine($"Registration Number is {stu1.RegistrationNumber} year is {stu1.AdmissionYear} percentage is {stu1.Percentage}");
    
        // Library lib=new Library();
        // lib[101]="C# Basics";
        // Console.WriteLine(lib[101]);
        // Console.WriteLine(lib["C# Basics"]);

        // Student1 std=new Student1(12);
    
        //Book book1=new Book();  


        // ArraysPractice obj=new ArraysPractice();
        // obj.Main();  

        // CollectionPrac obj=new CollectionPrac();
        // obj.Main();

        // FlipLogic obj=new FlipLogic();
        // Console.WriteLine("Enter the word");
        // string? word=Console.ReadLine();
        // string ans=obj.CleanseAndInvert(word);
        // if(!string.IsNullOrEmpty(ans))
        // Console.WriteLine("The generated key is - "+ans);
        // else
        // Console.WriteLine("Invalid Input"); 

        // ExceptionHandling obj=new ExceptionHandling();
        // obj.Run();

        // BankAccount obj = new BankAccount(-898);
        // obj.Withdraw(3423); 
        // TryExcept obj=new TryExcept();
        // obj.main();

        // RegExpression obj=new RegExpression();
        // obj.func1();

        LogProcessing.LogParser obj=new LogProcessing.LogParser();
        obj.main();
    }
}