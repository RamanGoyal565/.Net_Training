class SaleTransaction
{
    public string InvoiceNo{get;set;}
    public string CustomerName{get;set;}
    public string ItemName{get;set;}
    public int Quantity{get;set;}
    public double PurchaseAmount{get;set;}
    public double SellingAmount{get;set;}
    public string ProfitOrLossStatus{get;set;}
    public double ProfitOrLossAmount{get;set;}
    public double ProfitMarginPercent{get;set;}
}
class InvoiceService
{
    public static SaleTransaction LastTransaction;
    public static bool HasLastTransaction = false;
    public static void CreateNewInvoice()
    {
        SaleTransaction invoice = new SaleTransaction();
        do
        {
            Console.Write("Enter Invoice No: ");
            invoice.InvoiceNo = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(invoice.InvoiceNo));
        do
        {
            Console.Write("Enter Customer Name: ");
            invoice.CustomerName = Console.ReadLine();
        }
        while(!invoice.CustomerName.All(char.IsLetter));
        Console.Write("Enter Item Name: ");
        invoice.ItemName=Console.ReadLine();
        do
        {
            Console.Write("Enter Quantiyt: ");
            invoice.Quantity = Int32.Parse(Console.ReadLine());
        }
        while (invoice.Quantity <= 0);
        do
        {
            Console.Write("Enter Purchase Amount (total): ");
            invoice.PurchaseAmount= Double.Parse(Console.ReadLine());
        }
        while (invoice.PurchaseAmount <= 0);
        do
        {
            Console.Write("Enter Selling Amount (total): ");
            invoice.SellingAmount = Double.Parse(Console.ReadLine());
        }
        while (invoice.SellingAmount < 0);
        LastTransaction = invoice;
        HasLastTransaction = true;
        Console.WriteLine("\nTransaction saved successfully.");
        Calculate(invoice);
        Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
        Console.WriteLine("------------------------------------------------------------");
    }
    public static void Calculate(SaleTransaction trans)
    {
        if (trans.SellingAmount > trans.PurchaseAmount)
        {
            trans.ProfitOrLossStatus="PROFIT";
            trans.ProfitOrLossAmount=trans.SellingAmount-trans.PurchaseAmount;
        }
        else
        {
            trans.ProfitOrLossStatus="LOSS";
            trans.ProfitOrLossAmount=trans.PurchaseAmount-trans.SellingAmount;
        }
        trans.ProfitMarginPercent=trans.ProfitOrLossAmount/trans.PurchaseAmount*100;
    }
    public static void CalculateProfit()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }
        SaleTransaction transaction=LastTransaction;
        Calculate(transaction);
        Console.WriteLine("Profit or Loss Details");
        Console.WriteLine($"Status: {transaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {transaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {transaction.ProfitMarginPercent:F2}");
        Console.WriteLine("------------------------------------------------------------");
    }
    public static void ViewLastInvoice()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }
        SaleTransaction b = LastTransaction;
        Console.WriteLine("\n----------- Last Transaction -----------");
        Console.WriteLine($"InvoiceNo: {b.InvoiceNo}");
        Console.WriteLine($"Customer: {b.CustomerName}");
        Console.WriteLine($"Item: {b.ItemName}");
        Console.WriteLine($"Quatity: {b.Quantity}");
        Console.WriteLine($"Purchase Amount: {b.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {b.SellingAmount:F2}");
        Console.WriteLine($"Status: {b.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {b.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {b.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("------------------------------------------------------------");
    }
}