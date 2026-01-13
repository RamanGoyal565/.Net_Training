class Program
{
    static void Main(String[] args)
    {
        List<SensorReading> sensorHistory=new List<SensorReading>
        {
            new SensorReading { SensorId = 1, Type = "Distance", Value = 0.8, Confidence = 0.9, TimeStamp = new DateTime(2026,1,12,10,0,1) },
            new SensorReading { SensorId = 2, Type = "Battery", Value = 18, Confidence = 0.8, TimeStamp = new DateTime(2026,1,12,10,0,3) },
            new SensorReading { SensorId = 3, Type = "Temperature", Value = 92, Confidence = 0.7, TimeStamp = new DateTime(2026,1,12,10,0,4) },
            new SensorReading { SensorId = 4, Type = "Vibration", Value = 8.2, Confidence = 0.6, TimeStamp = new DateTime(2026,1,12,10,0,6) },
            new SensorReading { SensorId = 5, Type = "Battery", Value = 75, Confidence = 0.9, TimeStamp = new DateTime(2026,1,12,10,0,8) },
            new SensorReading { SensorId = 6, Type = "Distance", Value = 2.5, Confidence = 0.5, TimeStamp = new DateTime(2026,1,12,10,0,9) }
        };
        DateTime cutoff = new DateTime(2026, 1, 12, 10, 0, 0);
        DecisionEngine obj=new DecisionEngine();
        List<SensorReading> readings=obj.GetRecentReadings(sensorHistory,cutoff);
        
        Console.WriteLine("Battery Critical: "+obj.IsBatteryCritical(readings));
    
        Console.WriteLine("Nearest Obstancle "+obj.GetNearestObstacleDistance(readings));

        Console.WriteLine("Temperature Safe: "+obj.IsTemperatureSafe(readings));

        Console.WriteLine("Average Vibration: "+obj.GetAverageVibration(readings));

        Console.WriteLine("Sensor Health: ");
        var dict=obj.CalculateSensorHealth(sensorHistory);
        foreach(var i in dict)
            Console.WriteLine(i.Key+" "+i.Value);
        Console.WriteLine("Faulty Readings: ");
        var list=obj.DetectFaultySensors(sensorHistory);
        foreach(var i in list)
            Console.Write(i+", ");
        Console.WriteLine();
        Console.WriteLine("Batter Draining: "+obj.IsBatteryDrainingFast(sensorHistory));

        Console.WriteLine("Weighted Distance: "+obj.GetWeightedDistance(readings));

        Console.WriteLine("Robot Decision: "+obj.DecideRobotAction(sensorHistory,readings));
    }
}