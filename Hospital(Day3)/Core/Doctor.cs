class Doctor
{
    public static int totalDoctors;
    public readonly int licenseNumber;
    static Doctor()
    {
        totalDoctors=0;
    }
    public Doctor(string licenseNumber)
    {
        totalDoctors++;
        this.licenseNumber=licenseNumber;
    }
}