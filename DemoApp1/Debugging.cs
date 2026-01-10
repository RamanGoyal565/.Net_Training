using System.Diagnostics;
class Debugging
{
    public static void main()
    {
        Trace.WriteLine("Application started");
        int a=10;
        int b=0;
        try
        {
            int result=a/b;
            Console.WriteLine(result);
        }
        catch(Exception ex)
        {
            Trace.WriteLine("Exception occured: "+ex.Message);
        }
        Trace.WriteLine("Application ended");
    }
}