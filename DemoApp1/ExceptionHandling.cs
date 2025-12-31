class ExceptionHandling
{
    public void Run()
    {
        // int a=10;
        // int b=0;
        // try{
        //     int result=a/b;
        // }
        // catch(Exception ex){
        //     Console.WriteLine(ex.Message);
        // }
        // FileStream file = null;
        // try
        // {
        //     file = new FileStream("data.txt", FileMode.Open);
        //     // Perform file operations
        //     int data = file.ReadByte();
        //     Console.WriteLine(file.ReadByte());
        // }
        // catch (FileNotFoundException ex)
        // {
        //     Console.WriteLine("File not found: " + ex.Message);
        // }
        // finally
        // {
        //     if (file != null)
        //     {
        //         file.Close(); // Ensures file is always closed
        //         Console.WriteLine("File stream closed in finally block.");
        //     }
        // }
        try
        {
            try
            {
                File.ReadAllText("transactions.txt");
            }
            catch (IOException ioEx)
            {
                throw new ApplicationException(
                    "Unable to load transaction data",
                    ioEx
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("Root Cause: " + ex.InnerException.Message);
        }
    }
}
public class BankAccount
{
    public decimal Balance { get; private set; }
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));
        Balance = initialBalance;
    }
    public void Withdraw(decimal amount)
    {
        // Validate numeric range
        if (amount <= 0)
            throw new ArgumentException(
                "Withdrawal amount must be greater than zero",
                nameof(amount));

        // Enforce business rule
        if (amount > Balance)
            throw new InsufficientBalanceException(
                $"Cannot withdraw {amount:C}. Available balance: {Balance:C}");

        Balance -= amount;
    }
}
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message):base(message){}
}
// class BankAccount
// {
//     public decimal Balance{get;private set;}=5000;
//     public void Withdraw(decimal amount)
//     {
//         if(amount<=0)
//         throw new ArgumentException("Withdrawal must be greater than zero");
//         if (amount > Balance)
//         throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
//         Balance-=amount;
//     }
// }
// class TryExcept
// {
//     public void main()
//     {
//         try
//         {
//             Console.Write("Enter withdrawal amount: ");
//             decimal amount=decimal.Parse(Console.ReadLine());
//             int serviceCharge=100;
//             // int divisionCheck=serviceCharge/Int32.Parse("0");
//             string data=File.ReadAllText("account.txt");
//             BankAccount account=new BankAccount();
//             account.Withdraw(amount);
//             Console.WriteLine("Withdrawal Successful");
//         }
//         catch(FormatException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("Invalid input format.");
//         }
//         catch (DivideByZeroException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("Arthmetic error occurred.");
//         }
//         catch(FileNotFoundException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("File not found");
//         }
//         catch(InsufficientBalanceException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("Insuuficient Balance");
//         }
//         catch(Exception ex)
//         {
//             LogException(ex);
//             Console.WriteLine("An unexpected error occured.");
//         }
//         finally
//         {
//             Console.WriteLine("Transaction attempt completed");
//         }
//     }
//     static void LogException(Exception ex)
//     {
//         File.AppendAllText("error.log",DateTime.Now+" | "+ex.GetType().Name+" | "+ex.Message+Environment.NewLine);
//     }
// }