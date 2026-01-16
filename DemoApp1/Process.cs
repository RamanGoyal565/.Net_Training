using System;
using System.Threading;
using System.Diagnostics;

class Process_Prac
{
    static int counter=0;
    static Object lockobj=new Object();
    // public static void main()
    // {

    //     // Process currentProcess=Process.GetCurrentProcess();
    //     // Console.WriteLine(currentProcess.Id+" "+currentProcess.ProcessName+" "+currentProcess.StartTime);
    //     // Console.WriteLine(currentProcess.Threads+" "+currentProcess.WorkingSet64+" "+currentProcess.TotalProcessorTime);
    //     Process.Start("notepad.exe");
    //     // Process.Start("cmd.exe"); 
    //     // Create a new thread
    //     Thread worker = new Thread(DoWork);

    //     // Start the thread
    //     // worker.Start();

    //     // Console.WriteLine("Main thread continues...");

    //     // // Optional: Wait for worker thread to finish
    //     // worker.Join();
    //     // Console.WriteLine("Main thread finished");
    // }
    public static void main()
    {
        // Thread t1=new Thread(Increment);
        // Thread t2=new Thread(Increment);
        // t1.Start();
        // t2.Start();
        // t1.Join();
        // t2.Join();
        // Console.WriteLine("Final counter Value: "+counter);

        // try
        // {
        //     Task t=Task.Run(()=>throw new Exception("Task Error"));
        //     t.Wait();
        // }
        // catch(AggregateException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        Task task1=Task.Run(()=>Console.WriteLine("Task 1"));
        Task task2=Task.Run(()=>Console.WriteLine("Task 2"));
        Task.WhenAll(task1,task2).ContinueWith(t=>Console.WriteLine("All task Completed")).Wait();
    }
    static void Increment()
    {
        lock(lockobj)
        {
            for(int i=0;i<100000;i++)
                counter++;
        }
    }

    static void DoWork()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(500); // Simulate work
        }
    }
}