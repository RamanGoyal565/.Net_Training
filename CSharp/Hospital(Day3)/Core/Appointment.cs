class Appointments
{
    public void Schedule(Patient p,Doctor d)
    {
        Console.WriteLine($"Appointment Scheduled between patient {p.NameGetter()} and doctor {d.licenseNumber}");
    }
    public void Schedule(Patient p,Doctor d,DateTime date,string mode = "Offline")
    {
        Console.WriteLine($"Appointment Scheduled between patient {p.NameGetter()} and doctor {d.licenseNumber}");
        Console.WriteLine($"Appointment Scheduled date {date} and mode {mode}");
    }
}