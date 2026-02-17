using SensorData;
class Program
{
    public static void Main()
    {
        SensorDataProcessor obj = new SensorDataProcessor();
        string input=Console.ReadLine();
        float[] ?result=obj.Process(input);
        if (result == null)
        {
            Console.WriteLine("null");
        }
        else
        {
            Console.WriteLine("{ " + string.Join(", ",result.Select(x => x.ToString("F2"))) + " }");
        }
    }
}