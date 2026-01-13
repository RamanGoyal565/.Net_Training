using System.Linq;
class SensorReading
{
    public int SensorId{get;set;}
    public string Type{get;set;}
    public double Value{get;set;}
    public DateTime TimeStamp{get;set;}
    public double Confidence{get;set;}
}
enum RobotAction
{
    Stop,SlowDown,Reroute,Continue        
}
class DecisionEngine
{
    public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory,DateTime fromTime)
    {
        return sensorHistory.Where(s=>s.TimeStamp>=fromTime).ToList();
    }
    public bool IsBatteryCritical(List<SensorReading> readings)
    {
        return readings.Where(s=>s.Type=="Battery").Any(s=>s.Value<20);
    }
    public double GetNearestObstacleDistance(List<SensorReading> readings)
    {
        return readings.Where(s=>s.Type=="Distance").Min(s=>s.Value);
    }
    public bool IsTemperatureSafe(List<SensorReading> readings)
    {
        return readings.Where(s=>s.Type=="Temperature").All(s=>s.Value<90);
    }
    public double GetAverageVibration(List<SensorReading> readings)
    {
        return readings.Where(s=>s.Type=="Vibration").Select(s=>s.Value).DefaultIfEmpty(0.0).Average();
    }
    public Dictionary<string,double> CalculateSensorHealth(List<SensorReading> readings)
    {
        return readings.GroupBy(r=>r.Type).ToDictionary(g=>g.Key,g=>g.Average(r=>r.Confidence));
    }
    public List<string> DetectFaultySensors(List<SensorReading> readings)
    {
        return readings.Where(r=>r.Confidence<0.4).GroupBy(r=>r.Type).Where(g=>g.Count()>2).Select(g=>g.Key).ToList();        
    }
    public bool IsBatteryDrainingFast(List<SensorReading> readings)
    {
        var temp=readings.Where(r=>r.Type=="Battery").OrderBy(r=>r.TimeStamp);
        if(temp==null||temp.Count()<2)
        return false;
        return temp.Zip(temp.Skip(1),(prev,curr)=>curr.Value<prev.Value).All(x=>x);
    }
    public double GetWeightedDistance(List<SensorReading> readings)
    {
        var temp=readings.Where(r=>r.Type=="Distance");
        double weightedSum=temp.Select(r=>r.Value*r.Confidence).Sum();
        double totalConfidence=temp.Sum(r=>r.Confidence);
        if(totalConfidence==0)
            return double.MaxValue;
        return weightedSum/totalConfidence;
    }
    public RobotAction DecideRobotAction(List<SensorReading> recentReadings,List<SensorReading> sensorHistory)
    {
        if(IsBatteryCritical(recentReadings))
        return RobotAction.Stop;
        if(IsBatteryDrainingFast(sensorHistory))
        return RobotAction.Stop;
        if(GetNearestObstacleDistance(recentReadings)<1.0)
        return RobotAction.Reroute;
        if(!IsTemperatureSafe(recentReadings))
        return RobotAction.SlowDown;
        return RobotAction.Continue;
    }
}