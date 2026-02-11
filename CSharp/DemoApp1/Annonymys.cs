class StudentAnnonymys
{
    static (int sum,int average,int diff) Calculate(int a,int b)
    {
        return (a+b,(a+b)/2,a-b);
    }

    static (bool isValid,string message) ValidateUser(string userName)
    {
        if(string.IsNullOrEmpty(userName))
        return (false,"User Name is required");
        else
        return(true,"Valid user");
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public void Deconstruct(out int id, out string name)
    {
        id = Id;
        name = Name;
    }
}

