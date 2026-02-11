// using System;

// class Employee
// {
//     int Id;
//     string Name;
//     string Department;
//     float Salary;
//     char Gender;

//     public Employee(int Id,string Name,string Department,float Salary,char Gender)
//     {
//         this.Id = Id;
//         this.Name = Name;
//         this.Department = Department;
//         this.Salary = Salary;
//         this.Gender = Gender;

//     }
//     public void AcceptDetails()
//     {
//         Console.WriteLine("-----------------Enter Employees Details---------------------");
//         Console.Write("Enter Employee Id ::>> ");
//         Id = Convert.ToInt32(Console.ReadLine());
//         // Id = int.Parse(Console.ReadLine());


//         Console.Write("Enter Employee Name ::>> ");
//         Name = Console.ReadLine()!;


//         Console.Write("Enter Employee Department ::>> ");
//         Department = Console.ReadLine()!;


//         Console.Write("Enter Employee Salary ::>> ");
//         Salary = Convert.ToSingle(Console.ReadLine());

//         Console.Write("Enter Employee Gender ::>> ");
//         Gender = Convert.ToChar(Console.ReadLine()!);

//     }
//     public void DisplayDetails()
//     {
//         // Console.WriteLine("===============EMPLOYEE DETAILS ARE==============");
//         // Console.WriteLine("ID is ::>> "+Id);
//         // Console.WriteLine("Name is ::>> "+Name);
//         // Console.WriteLine("Department is ::>> "+Department);
//         // Console.WriteLine("Salary is ::>> "+Salary);
//         // Console.WriteLine("Gender is ::>> "+Gender);


//         Console.WriteLine("===============EMPLOYEE DETAILS ARE==============");
//         Console.WriteLine($"ID is ::>> {Id}");
//         Console.WriteLine($"Name is ::>> {Name}");
//         Console.WriteLine($"Department is ::>> {Department}");
//         Console.WriteLine($"Salary is ::>> {Salary}");
//         Console.WriteLine($"Gender is ::>> {Gender}");
//     }
// }