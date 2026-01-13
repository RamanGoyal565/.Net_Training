using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Xml.Serialization;
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

        // LogProcessing.LogParser obj=new LogProcessing.LogParser();
        // obj.main();

        // GarbageCollector.main();
        // (int,string) data=(101,"Raman");
        // var student=new {Id=101,Name="Amit"};
        // Console.WriteLine(data.GetType());
        // Console.WriteLine(student.GetType());

        // Console.WriteLine(Calculate(45,23).sum);
        // var response=ValidateUser("Admin");
        // Console.WriteLine(response.message);

        // var person=(Id:12,Name:"Raman");
        // var(id,name)=person;
        // Console.WriteLine(id);
        // Console.WriteLine(id.GetType());

        // var(_,userName)=person;
        // Console.WriteLine(userName+" "+userName.GetType());

        // var s = new StudentAnnonymys { Id = 1, Name = "Amit" };
        // Console.WriteLine(s.GetType());
        // var (sid, sname) = s;

        // Console.WriteLine(sid);
        // Console.WriteLine(sname);

        // LINQ.main();

        // using(ResourceHandler handler=new ResourceHandler())
        // {
        //     Console.WriteLine("Using Resource");
        // }
        // Console.WriteLine("End of Program");
       
        // PaymentService service=new PaymentService();
        // PaymentDelegate payment=null;
        // payment+=service.RTGS;
        // payment+=service.ProcessPayment;
        // decimal amount=5000;
        // if (amount.IsValidPayment())
        // {
        //     payment(amount);    
        // }
        // else
        // {
        //     Console.WriteLine("Invalid payment found");
        // }

        // Action<string> logActivity=message=>
        // Console.WriteLine("Log Activity: "+message);
        // logActivity("User logged in at 10:30 AM");

        // Func<decimal,decimal,decimal> calculateDiscount=(price,discount)=>price-(price*discount/100);
        // Console.WriteLine(calculateDiscount(1000,10));

        // Predicate<int> isEligible=age=>age>=18;
        // Console.WriteLine(isEligible(20));

        // Button btn=new Button();
        // btn.Clicked+=()=>Console.WriteLine("Button Clicked");
        // btn.Clicked+=()=>Console.WriteLine("Event triggered");
        // btn.Clicked+=()=>Console.WriteLine("With help of Delegate");
        // btn.Click();

        // SmartHomeSecurity.Program.main();

        // Comparison<int> sortDescending=(a,b)=>b.CompareTo(a);
        // Console.WriteLine(sortDescending(5,10));
        // Console.WriteLine(sortDescending(10,5));
        // Console.WriteLine(sortDescending(5,5));
        
        // File_Program.main();

        // Directory.CreateDirectory("Logs");
        // if (Directory.Exists("Logs"))
        // {
        //     Console.WriteLine("Logs directory created successfully");
        // }

        // Directory_Program.main();

        // User user=new User{Id=1,Name="Raman"};
        // string json=JsonSerializer.Serialize(user);
        // File.WriteAllText("user.json",json);

        // string json=File.ReadAllText("user.json");
        // User user=JsonSerializer.Deserialize<User>(json);
        // Console.WriteLine($"User Loaded: {user.Id},{user.Name}");

        // XmlSerializer ser=new XmlSerializer(typeof(User));
        // using(FileStream fs=new FileStream("user.xml",FileMode.Create))
        // {
        //     ser.Serialize(fs,user);
        // }
        // Console.WriteLine("Xml Serialized");
        
        // Debugging.main();
        // Program_Debugging.main();

        Assemblies_Reflection.main();
    }
}