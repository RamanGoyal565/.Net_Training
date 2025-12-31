class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());
            BankAccount account = new BankAccount(accNo, initialBalance);
            Console.Write("Enter Withdrawal Amount: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (BankOperationException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}