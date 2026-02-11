interface I1
{
    void M1();
    void M2();
}
interface I2
{
    void M3();
}
interface I3
{
    void M4();
}
public class A:I1,I2,I3
{
    public void M1()
    {
        Console.WriteLine("Inside M1 method");
    }
    public void M2()
    {
        Console.WriteLine("Inside M2 method");
    }
    public void M3()
    {
        Console.WriteLine("Inside M3 method");
    }
    public void M4()
    {
        Console.WriteLine("Inside M4 method");
    }
}
class B : A
{
    public void M5()
    {
        Console.WriteLine("Inside M5 method");
    }
}