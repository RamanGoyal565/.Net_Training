using System;
using System.Collections.Generic;
public class Program
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        Console.WriteLine("Enter Creator Name:");
        record.CreatorName = Console.ReadLine();
        record.WeeklyLikes = new double[4];
        Console.WriteLine("Enter weekly likes (Week 1 to 4):");
        for (int i = 0; i < 4; i++)
        {
            record.WeeklyLikes[i] = double.Parse(Console.ReadLine());
        }
        EngagementBoard.Add(record);
        Console.WriteLine("Creator registered successfully");
        Console.WriteLine();
    }
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (CreatorStats creator in records)
        {
            int count = 0;
            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }
        return result;
    }
    public double CalculateAverageLikes()
    {
        if (EngagementBoard.Count == 0)
            return 0;
        double total = 0;
        int count = 0;
        foreach (CreatorStats creator in EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                total += likes;
                count++;
            }
        }
        return total / count;
    }
    public void Menu()
    {
        Console.WriteLine("1. Register Creator");
        Console.WriteLine("2. Show Top Posts");
        Console.WriteLine("3. Calculate Average Likes");
        Console.WriteLine("4. Exit");
        Console.WriteLine("Enter your choice:");
    }
    public static void Main(string[] args)
    {
        Program obj = new Program();
        int choice;
        do
        {
            obj.Menu();
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    obj.RegisterCreator(new CreatorStats());
                    break;
                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());
                    Dictionary<string, int> result =
                        obj.GetTopPostCounts(EngagementBoard, threshold);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Overall average weekly likes: " +
                        obj.CalculateAverageLikes());
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine();
                    break;
            }
        }
        while (choice != 4);
    }
}