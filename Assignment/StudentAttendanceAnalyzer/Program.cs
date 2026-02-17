using System.Text;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(",");
        Dictionary<int,bool?> attendance=new Dictionary<int, bool?>();
        foreach(string s in input)
        {
            string[] record = s.Split(":");
            if (int.TryParse(record[0], out int Id))
            {
                if (record.Length == 1)
                    attendance.Add(Id, null);
                switch (record[1])
                {
                    case "Present":
                        attendance.Add(Id, true);
                        break;
                    case "Absent":
                        attendance.Add(Id, false);
                        break;
                    default:
                        attendance.Add(Id, null);
                        break;
                }
            }
            else
                continue;
        }
        StringBuilder report=new StringBuilder();
        report.Append("Attendance Report\n-----------------\n");
        int totalPresent = 0;
        int totalAbsent = 0;
        int notMarked = 0;

        foreach (var record in attendance)
        {
            string status;
            if (record.Value == true)
            {
                status = "Present";
                totalPresent++;
            }
            else if (record.Value == false)
            {
                status = "Absent";
                totalAbsent++;
            }
            else
            {
                status = "Not Marked";
                notMarked++;
            }
            report.Append($"{record.Key} {status}\n");
        }
        report.Append($"Total Present: {totalPresent}\n");
        report.Append($"Total Absent: {totalAbsent}\n");
        report.Append($"Not Marked: {notMarked}\n");
        Console.WriteLine(report.ToString());
    }
}