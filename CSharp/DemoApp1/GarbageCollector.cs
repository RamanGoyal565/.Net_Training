using System;
class GarbageCollector
{
    public static void main()
    {
        // Console.WriteLine("Creating Objects");
        // List<MyClass> list=new List<MyClass>();
        // for(int i = 0; i < 5; i++)
        // {
        //     list.Add(new MyClass());
        // }
        // list.Clear();
        // list=null;
        // Console.WriteLine("Forcing Garbage Collection");
        // GC.Collect();
        // GC.WaitForPendingFinalizers();
        // Console.WriteLine("Garbage Collection Complete");

        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");

    }
}
class MyClass
{
    ~MyClass()
    {
        Console.WriteLine("Finalizer called, object collected");
    }
}

class ResourceHandler : IDisposable
{
    public ResourceHandler()
    {
        Console.WriteLine("Resource Called");
    }
    public void Dispose()
    {
        Console.WriteLine("Dispose method called");
    }
}