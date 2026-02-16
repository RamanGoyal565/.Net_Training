class Program
{
    public static void Main(String[] args)
    {
        try
        {
            ShipmentDetails shipment = new ShipmentDetails();
            Console.Write("Input ID: ");
            shipment.ShipmentCode = Console.ReadLine();
            if (!shipment.ValidateShipmentCode())
            {
                Console.WriteLine("Invalid shipment code");
                return;
            }
            Console.Write("Mode: ");
            shipment.TransportMode = Console.ReadLine();
            Console.Write("Weight: ");
            shipment.Weight = double.Parse(Console.ReadLine());
            Console.Write("Storage: ");
            shipment.StorageDays = int.Parse(Console.ReadLine());
            Console.WriteLine($"The total shipping cost is {shipment.CalculateTotalCost():F2}");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}