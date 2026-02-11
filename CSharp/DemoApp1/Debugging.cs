using System.Diagnostics;
class Debugging
{
    public static void main()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
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
class User
{
    public string ?Name{get;set;}
    public int Age{get;set;}
}
class Program_Debugging
{
    public static void Validate(User user)
    {
        Console.WriteLine(user.Name+" "+user.Age);
    }
    public static void main()
    {
        // int total=0;
        // for(int i = 0; i < 10; i++)
        // {
        //     total+=i;
        // }
        // Console.WriteLine(total);
        List<User> users=new List<User>();
        users.Add(new User{Name = "Aryan", Age = 22});
        users.Add(new User{Name = "Mohit", Age = 32});
        users.Add(new User{Name = "Sushant", Age = 68});
        users.Add(new User{Name = "Ritik", Age = 63});
        users.Add(new User{Name = "Sahil", Age = 52});
        Queue<int> queue=new Queue<int>();
        queue.Enqueue(32);
        queue.Enqueue(34);
        queue.Enqueue(43);
        queue.Enqueue(34);
        foreach(var user in users)
        {
            Validate(user);

        }
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
    }
    //     Trace.Listeners.Add(new ConsoleTraceListener());

    //     Trace.WriteLine("Program started");

    //     PerformCalculation(10, 5);
    //     PerformCalculation(10, 0);   // Error case

    //     Trace.WriteLine("Program ended");
    // }

    // static void PerformCalculation(int a, int b)
    // {
    //     Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

    //     if (b == 0)
    //     {
    //         Trace.WriteLine("Error: Division by zero detected");
    //         return;
    //     }

    //     int result = Divide(a, b);

    //     Trace.WriteLine($"Calculation successful | Result={result}");
    //     Trace.WriteLine("Exiting PerformCalculation");
    // }

    // static int Divide(int x, int y)
    // {
    //     Trace.WriteLine($"Dividing values | x={x}, y={y}");
    //     return x / y;
    // }
}