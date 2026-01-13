delegate string ReportGenerator(string patientName);
delegate void HospitalAlert(string message);
delegate void HospitalNotificationHandler(string message,DateTime time);
class HospitalNotifier
{
    public event HospitalNotificationHandler PatientAdmitted;
    public void AdmitPatient(string name)
    {
        PatientAdmitted?.Invoke($"{name} admitted successfully",DateTime.Now);
    }

}
class AdministrationDepartment
{
    public void Notify(string message,DateTime time)
    {
        Console.WriteLine(message);
        Console.WriteLine($"Admitted at time {time}");
    }
}
