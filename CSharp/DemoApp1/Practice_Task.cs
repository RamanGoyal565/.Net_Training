class Practice_Task
{
    public static void main()
    {
        List<int> divisibleBy2=new List<int>();
        List<int> divisibleBy3=new List<int>();
        List<int> notDivisible=new List<int>();
        for(int i = 1; i <= 100; i++)
        {
            if(i%2==0)
                divisibleBy2.Add(i);
            if(i%3==0)
                divisibleBy3.Add(i);
            if(i%2!=0&&i%3!=0)
                notDivisible.Add(i);
        }
        Console.WriteLine("Divisible by 2");
        foreach(int i in divisibleBy2)
            Console.Write(i+" ");
        Console.WriteLine("\nDivisible by 3");
        foreach(int i in divisibleBy3)
            Console.Write(i+" ");
        Console.WriteLine("\nNot Divisible");
        foreach(int i in notDivisible)
            Console.Write(i+" ");
    }
}