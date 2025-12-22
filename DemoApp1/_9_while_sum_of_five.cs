class SumOfNumberWhile
{
    public void sum()
    {
        int count = 0;
        int sum = 0;
        while(count <= 5)
        {
            sum += count;
            count++;
        }
        Console.WriteLine("Sum of 0-5 is "+sum);

    }
}