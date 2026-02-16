using System;
using System.Text.RegularExpressions;
public class ShipmentDetails:Shipment
{ 
    public bool ValidateShipmentCode()
    {
        string regex = @"^GC#[0-9]{4}";
        return Regex.IsMatch(ShipmentCode, regex);
    }
    public double CalculateTotalCost()
    {
        double cost = 0;
        double rate = 0;
        switch (TransportMode)
        {
            case "Sea":
                rate = 15.00;
                break;
            case "Air":
                rate = 50.00;
                break;
            case "Land":
                rate = 25.00;
                break;
        }
        cost = Weight * rate + Math.Sqrt(StorageDays);
        return Math.Round(cost,2);
    }
}
