class ContinueStatement
{
    public void Game()
    {
        Console.WriteLine("Game Begins");
        for(int i=1;i<=10;i++)
        {
            if (i == 4)
            {
                Console.WriteLine("E4 is invisible Skipping e4");
                continue;                           
            }
            Console.WriteLine("Player killed e{0}",i);
        }
        Console.WriteLine("Game End");
    }
}