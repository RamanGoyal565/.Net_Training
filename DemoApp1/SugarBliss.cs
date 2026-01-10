class Chocolate
{
    public string Flavour{get;set;}
    public int Quantity{get;set;}
    public int PricePerUnit{get;set;}
    public double TotalPrice{get;set;}
    public double DiscountedPrice{get;set;}
    public bool ValidateChocolateFlavour()
    {
        if(Flavour=="Dark"||Flavour=="Milk"||Flavour=="White")
            return true;
        return false;
    }
    public void DiscountCalculation()
    {
        int discountper=0;
        switch (Flavour)
        {
            case "Dark":
            discountper=18;
            break;
            case "Milk":
            discountper=12;
            break;
            case "White":
            discountper=6;
            break;
            default:
            return;
        }
        TotalPrice=Quantity*PricePerUnit;
        DiscountedPrice=TotalPrice-(TotalPrice*discountper/100);
        Console.WriteLine("Flavour "+Flavour);
        Console.WriteLine("Quantity "+Quantity);
        Console.WriteLine("Price Per Unit "+PricePerUnit);
        Console.WriteLine("Total Price "+TotalPrice);
        Console.WriteLine("Discounted Price "+DiscountedPrice);
    }
    public static void main()
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
