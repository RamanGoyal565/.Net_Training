interface IPrintable
{
    static int count;
    void Print();
    void Scan();
}

class Report : IPrintable
{
    public void Scan()
    {
        Console.WriteLine("Scanning report");
    }
    public void Print()
    {
        Console.WriteLine("Printing report");
    }
}


interface ILogger
{
    void Log();
}
interface INotifier
{
    void Log();
}
class FileLogger : ILogger, INotifier
{
    void ILogger.Log()
    {
        Console.WriteLine("Logging to file via ILogger");
    }
    void INotifier.Log()
    {
        Console.WriteLine("Logging to notification via INotifier");
    }
}


