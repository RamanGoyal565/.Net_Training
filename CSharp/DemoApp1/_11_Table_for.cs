class TableUsingForLoop
{
    public void PrintTable()
    {
        for(int i=20;i<=30;i++)
        {
            Console.WriteLine("Table of {0}",i);
            for(int j=1;j<=10;j++)
            {
                Console.WriteLine("{0} x {1} = {2}",i,j,i*j);
            }
            Console.WriteLine("\n");
        }
    }
}