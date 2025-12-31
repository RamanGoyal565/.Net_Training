class Program
{
    public static void Main(String[] args)
    {
        int choice = 0;
        do
        {
            Console.WriteLine("\n================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            bool valid = Int32.TryParse(Console.ReadLine(), out choice);
            if (!valid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    BillingService.CreateNewBill();
                    break;
                case 2:
                    BillingService.ViewLastBill();
                    break;
                case 3:
                    BillingService.ClearLastBill();
                    break;
                case 4:
                    Console.WriteLine("Thank you. Application closed normally.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select between 1 and 4.");
                    break;
            }
        } while (choice != 4);
    }
}