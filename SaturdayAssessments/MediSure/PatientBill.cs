class PatientBill
{
    public string BillId{get;set;}
    public string PatientName{get;set;}
    public bool HasInsurance{get;set;}
    public double ConsultationFee{get;set;}
    public double LabCharges{get;set;}
    public double MedicineCharges{get;set;}
    public double GrossAmount{get;set;}
    public double DiscountAmount{get;set;}
    public double FinalPayable{get;set;}
}

class BillingService
{
    public static PatientBill LastBill;
    public static bool HasLastBill = false;
    public static void CreateNewBill()
    {
        PatientBill bill = new PatientBill();
        do
        {
            Console.Write("Enter Bill Id: ");
            bill.BillId = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(bill.BillId));
        do
        {
            Console.Write("Enter Patient Name: ");
            bill.PatientName = Console.ReadLine();
        }
        while(!bill.PatientName.All(char.IsLetter));
        Console.Write("Is the patient insured? (Y/N): ");
        char ins = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
        bill.HasInsurance = (ins == 'Y');
        do
        {
            Console.Write("Enter Consultation Fee: ");
            bill.ConsultationFee = Double.Parse(Console.ReadLine());
        }
        while (bill.ConsultationFee <= 0);
        do
        {
            Console.Write("Enter Lab Charges: ");
            bill.LabCharges = Double.Parse(Console.ReadLine());
        }
        while (bill.LabCharges < 0);
        do
        {
            Console.Write("Enter Medicine Charges: ");
            bill.MedicineCharges = Double.Parse(Console.ReadLine());
        }
        while (bill.MedicineCharges < 0);
        bill.GrossAmount = bill.ConsultationFee + bill.LabCharges + bill.MedicineCharges;
        if (bill.HasInsurance)
        {
            bill.DiscountAmount = bill.GrossAmount * 0.10;
        }
        else
        {
            bill.DiscountAmount = 0;
        }
        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;
        LastBill = bill;
        HasLastBill = true;
        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
        Console.WriteLine("------------------------------------------------------------");
    }
    public static void ViewLastBill()
    {
        if (!HasLastBill)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }
        PatientBill b = LastBill;
        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine($"BillId: {b.BillId}");
        Console.WriteLine($"Patient: {b.PatientName}");
        Console.WriteLine($"Insured: {(b.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {b.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {b.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {b.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {b.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {b.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {b.FinalPayable:F2}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("------------------------------------------------------------");
    }
    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}    