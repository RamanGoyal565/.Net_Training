public delegate int Cal(int a,int b);
public delegate int StringCal(String s);
class Delegate_Prac
{
    public int Add(int a,int b)
    {
        return a+b;
    }
    public int Subtract(int a,int b)
    {
        return a-b;
    }
    public int Length(string s)
    {
        return s.Length;
    }
    public static void main()
    {
        Delegate_Prac obj=new Delegate_Prac();
        Cal cal = obj.Add;
        cal+=obj.Subtract;
        cal?.Invoke(10,5);
    }
}