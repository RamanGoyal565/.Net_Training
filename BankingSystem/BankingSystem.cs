public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message): base(message)
    {}
}
public class BankOperationException : Exception
{
    public BankOperationException(string message, Exception innerException): base(message, innerException)
    {}
}
class BankAccount
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number cannot be null or empty.");
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }
    public void Withdraw(decimal amount)
    {
        try
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            if (amount > Balance)
                throw new InsufficientBalanceException("Insufficient balance.");
            Balance -= amount;
            Console.WriteLine($"Withdrawal successful. Updated balance: {Balance}");
        }
        catch (InsufficientBalanceException ex)
        {
            LogException(ex);
            throw;
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw new BankOperationException("Unexpected banking error.", ex);
        }
    }
    private void LogException(Exception ex)
    {
        string log =
            $"[{DateTime.Now}]\n" +
            $"Account Number: {AccountNumber}\n" +
            $"Exception: {ex}\n" +
            "-----------------------------\n";
        File.AppendAllText("BankErrorLog.txt", log);
    }
}