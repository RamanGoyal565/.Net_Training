class Program{
    public static void Main(string[] args)
    {
        Chocolate obj=new Chocolate();
        Console.WriteLine("Enter Chocolate Flavour");
        obj.Flavour=Console.ReadLine();
        Console.WriteLine("Enter Quantity");
        obj.Quantity=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Price Per Unit");
        obj.PricePerUnit=Convert.ToInt32(Console.ReadLine());
        if (obj.ValidateChocolateFlavour())
        {
            obj.DiscountCalculation();
        }
        else
        {
            Console.WriteLine("Invalid Flavour");
        }
    }
}