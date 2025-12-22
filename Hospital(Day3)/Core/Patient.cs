class Patient
{
    public readonly int patientId;
    public string name;
    public int age;
    private string medicalHistory;
    public Patient(int id)
    {
        patientId=id;
    }
    public string NameGetter()
    {
        return name;
    }
    public void NameSetter(string name)
    {
        this.name=name;
    }
    public int AgeGetter()
    {
        return age;
    }
    public void AgeSetter(int age)
    {
        this.age=age;
    }
    public void SetMedicalHistory(string history)
    {
        medicalHistory=history;
    }
    public string GetMedicalHistiory()
    {
        return medicalHistory;
    }
}