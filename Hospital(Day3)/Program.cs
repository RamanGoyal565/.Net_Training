// See https://aka.ms/new-console-template for more information
using System.Reflection;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter Patient ID: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Patient Name: ");
            string patientName = Console.ReadLine();
            Console.WriteLine("Enter Patient Age: ");
            int age = InputValidator.ReadAge(Console.ReadLine());
            Console.WriteLine("Enter Medical History: ");
            string history = Console.ReadLine();
            Patient patient = new Patient(patientId, patientName, age);
            patient.SetMedicalHistory(history);
            Console.WriteLine("Enter Doctor License Number: ");
            int licenseNumber = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor(licenseNumber);
            Appointment.Schedule(patient, doctor, DateTime.Now,"Online");
            string condition = "Normal";
            string riskLevel;
            DiagnosisService.Evaluate(in age,ref condition,out riskLevel,80, 90, 100);
            Console.WriteLine("Condition: " + condition);
            Console.WriteLine("Risk Level: " + riskLevel);
            Console.WriteLine("Enter number of hospital stay days: ");
            int days = Convert.ToInt32(Console.ReadLine());
            int stayDays = HospitalStay.CalculateStayDays(days);
            Console.WriteLine("Total Hospital Stay Days: " + stayDays);
            double roomChargePerDay = 1000;
            double roomCharges = stayDays * roomChargePerDay;
            Billing bill = new Billing();
            bill.consultationFee = 500;
            bill.testCharges = 1500;
            bill.roomCharges = roomCharges;
            double totalBill = bill.Total();
            double finalPayable =InsuranceService.ApplyCoverage(totalBill, 20);
            Console.WriteLine("Final Payable Amount: " + finalPayable);
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }
}