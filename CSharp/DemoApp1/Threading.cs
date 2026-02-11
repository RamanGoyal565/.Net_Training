using System.Threading;
class Threading_Prac
{
    public static void main(){
        Thread thread=new Thread(new ParameterizedThreadStart(PrintMessage));
        thread.Start("hello from thread");
        Thread thread1=new Thread(DoWork);
        thread1.Start();
        Console.WriteLine("Hello from main thread");
    }
    static void PrintMessage(object message)
    {
        Console.WriteLine(message);

    }
    static void DoWork()
    {
        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}