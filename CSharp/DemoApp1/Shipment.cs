using System.Text.RegularExpressions;
using System;
class Shipment
{
    public string ShipmentCode{get;set;}
    public string TransportMode{get;set;}
    public double Weight{get;set;}
    public int StorageDays{get;set;}
}
class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        string regex=@"^GC#\d{4}$";
        return Regex.IsMatch(ShipmentCode, regex);
    }
    public double CalculateTotalCost()
    {
        double ratePerKg = 0;
        switch (TransportMode)
        {
            case "Sea": ratePerKg = 15; break;
            case "Air": ratePerKg = 50; break;
            case "Land": ratePerKg = 25; break;
            default: return 0.00;
        }
        double cost = (Weight * ratePerKg) + Math.Sqrt(StorageDays);
        return Math.Round(cost, 2);
    }
}