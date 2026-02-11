class Program
{
    public static void Menu()
    {
        Console.WriteLine("1. Task 1 Average Product Price");
        Console.WriteLine("2. Task 2 Branch Month Sales");
        Console.WriteLine("3. Task 3 Jagged Array");
        Console.WriteLine("4. Task 4 Duplicate Customer ID");
        Console.WriteLine("5. Task 5 Sorting Above Average Transactions");
        Console.WriteLine("6. Task 6 Flow of Operations");
        Console.WriteLine("7. Task 7 Non Generic Collections");
        Console.WriteLine("8. Exit");
    }
    public static void Main(string[] args)
    {
        int choice=0;
        do{
            Program.Menu();
            Console.WriteLine("Enter your choice");
            choice=Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Task1_ProductPrice.Run();
                    break;
                case 2:
                    Task2_BranchSales.Run();
                    break;
                case 3:
                    Task3_JaggedExtraction.Run();
                    break;
                case 4:
                    Task4_CustomerCleaning.Run();
                    break;
                case 5:
                    Task5_FinancialFiltering.Run();
                    break;
                case 6:
                    Task6_ProcessFlow.Run();
                    break;
                case 7:
                    Task7_LegacyRisk.Run();
                    break;
                case 8:
                    Console.WriteLine("PROGRAM COMPLETED SUCCESSFULLY");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }while(choice!=8);
    }
}
