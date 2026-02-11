sealed class Security
{
    private string? password="123456";
    public string Password
    {
        set
        {
            password=value;
        }
    }
    public bool Authenticate(string pass)
    {
        if(pass==password)
        {
            Console.WriteLine("User Authentication Successfull");
            return true;
        }
        return false;
    }
}