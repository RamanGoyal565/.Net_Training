using HealthSync;
using System;
class Program
{
    public static void Main()
    {
        Consultant consultant=null;
        string choice = "";
        do
        {
            try
            {
                Console.WriteLine("1. In-House");
                Console.WriteLine("2. Visiting");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter Choice");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        InHouse inHouse = new InHouse();
                        Console.Write("Id: ");
                        inHouse.Id = Console.ReadLine();
                        if (!inHouse.ValidateConsultantId())
                        {
                            Console.WriteLine("Invalid doctor id");
                            break;
                        }
                        Console.Write("MonthlyStripend: ");
                        inHouse.MonthlyStripend = double.Parse(Console.ReadLine());
                        consultant = inHouse;
                        break;
                    case "2":
                        Visiting visiting=new Visiting();
                        visiting.Id = Console.ReadLine();
                        if (!visiting.ValidateConsultantId())
                        {
                            Console.WriteLine("Invalid doctor id");
                            break;
                        }
                        Console.Write("Visits: ");
                        visiting.Visits=int.Parse(Console.ReadLine());
                        Console.Write("Rate: ");
                        visiting.Rate = double.Parse(Console.ReadLine());
                        consultant = visiting;
                        break;
                    case "3":
                        Console.WriteLine("Exiting");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                if(consultant != null)
                {
                    consultant.CalculateTax();
                    consultant.DisplayDetails();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        while (choice != "3");
    }
}