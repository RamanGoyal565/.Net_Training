using System;
using System.Collections;
using System.Collections.Generic;

static class SharedData
{
    public static double AveragePrice;
    public static int[,] SalesData;
    public static int Branches;
    public static int Months;
}

class Task1_ProductPrice
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 1: PRODUCT PRICE ANALYSIS =====");
        Console.Write("Enter number of products: ");
        int n = int.Parse(Console.ReadLine());
        int[] prices = new int[n];
        for (int i = 0; i < n; i++)
        {
            int value;
            do
            {
                Console.Write($"Enter price for product {i+1}: ");
                value = int.Parse(Console.ReadLine());
            } while (value <= 0);
            prices[i] = value;
        }
        double sum = 0;
        foreach (int p in prices) sum += p;
        SharedData.AveragePrice = sum / prices.Length;
        Console.WriteLine($"Average Price: {SharedData.AveragePrice:F2}");
        Array.Sort(prices);
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < SharedData.AveragePrice)
            {
                prices[i] = 0;
            }
        }
        int oldSize = prices.Length;
        Array.Resize(ref prices, prices.Length + 5);
        for (int i = oldSize; i < prices.Length; i++)
        {
            prices[i] = (int)SharedData.AveragePrice;
        }
        Console.WriteLine("Final Product Array:");
        for (int i = 0; i < prices.Length; i++)
        {
            Console.WriteLine($"Index {i+1}: {prices[i]}");
        }
    }
}
class Task2_BranchSales
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 2: BRANCH SALES ANALYSIS =====");
        Console.Write("Enter number of branches: ");
        SharedData.Branches = Int32.Parse(Console.ReadLine());
        Console.Write("Enter number of months: ");
        SharedData.Months = Int32.Parse(Console.ReadLine());
        SharedData.SalesData = new int[SharedData.Branches, SharedData.Months];
        for (int b = 0; b < SharedData.Branches; b++)
        {
            for (int m = 0; m < SharedData.Months; m++)
            {
                do
                {
                    Console.Write($"Enter sales for Branch {b+1}, Month {m+1}: ");
                    SharedData.SalesData[b, m] = Int32.Parse(Console.ReadLine());    
                }
                while(SharedData.SalesData[b, m]<=0);
            }
        }
        int highest = int.MinValue;
        for (int b = 0; b < SharedData.Branches; b++)
        {
            int total = 0;
            for (int m = 0; m < SharedData.Months; m++)
            {
                total += SharedData.SalesData[b, m];
                if (SharedData.SalesData[b, m] > highest)
                    highest = SharedData.SalesData[b, m];
            }
            Console.WriteLine($"Branch {b+1} Total Sales: {total}");
        }
        Console.WriteLine($"Highest Monthly Sale: {highest}");
    }
}
class Task3_JaggedExtraction
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 3: JAGGED ARRAY EXTRACTION =====");
        int[][] jagged = new int[SharedData.Branches][];
        for (int b = 0; b < SharedData.Branches; b++)
        {
            int count = 0;
            for (int m = 0; m < SharedData.Months; m++){
                if (SharedData.SalesData[b, m] >= SharedData.AveragePrice)
                {
                    count++;
                }
            }
            jagged[b] = new int[count];
            int index = 0;
            for (int m = 0; m < SharedData.Months; m++)
            {
                if (SharedData.SalesData[b, m] >= SharedData.AveragePrice)
                {
                    jagged[b][index++] = SharedData.SalesData[b, m];
                }
            }
        }
        for (int b = 0; b < jagged.Length; b++)
        {
            Console.Write($"Branch {b+1}: ");
            foreach (int val in jagged[b])
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }
}
class Task4_CustomerCleaning
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 4: CUSTOMER TRANSACTION CLEANING =====");
        Console.Write("Enter number of transactions: ");
        int n = Int32.Parse(Console.ReadLine());
        List<int> customers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter customer ID {i}: ");
            customers.Add(Int32.Parse(Console.ReadLine()));
        }
        HashSet<int> unique = new HashSet<int>(customers);
        List<int> cleaned = new List<int>(unique);
        Console.WriteLine("Cleaned Customer IDs:");
        foreach (int id in cleaned)
        {
            Console.WriteLine(id);
        }
        Console.WriteLine($"Duplicates Removed: {customers.Count - cleaned.Count}");
    }
}
class Task5_FinancialFiltering
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 5: FINANCIAL TRANSACTION FILTERING =====");
        Console.Write("Enter number of transactions: ");
        int n = Int32.Parse(Console.ReadLine());
        Dictionary<int, double> data = new Dictionary<int, double>();
        for (int i = 0; i < n; i++)
        {
            int id;
            do
            {
                Console.Write("Enter transaction ID: ");
                id = Int32.Parse(Console.ReadLine());
            } while (data.ContainsKey(id));
            Console.Write("Enter amount: ");
            data.Add(id, Double.Parse(Console.ReadLine()));
        }
        SortedList<int, double> sorted = new SortedList<int, double>();
        foreach (var item in data)
        {
            if (item.Value >= SharedData.AveragePrice)
            {
                sorted.Add(item.Key, item.Value);
            }
        }
        Console.WriteLine("High Value Transactions:");
        foreach (var item in sorted)
        {
            Console.WriteLine($"ID: {item.Key}, Amount: {item.Value}");
        }
    }
}

class Task6_ProcessFlow
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 6: PROCESS FLOW MANAGEMENT =====");
        Console.Write("Enter number of operations: ");
        int n = Int32.Parse(Console.ReadLine());
        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter operation {i}: ");
            string op = Console.ReadLine();
            queue.Enqueue(op);
            stack.Push(op);
        }
        Console.WriteLine("Processing Queue:");
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
        Console.WriteLine("Undo Last Two Operations:");
        for (int i = 0; i < 2 && stack.Count > 0; i++)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}
class Task7_LegacyRisk
{
    public static void Run()
    {
        Console.WriteLine("\n===== TASK 7: LEGACY DATA RISK =====");
        Console.Write("Enter number of users: ");
        int n = int.Parse(Console.ReadLine());
        Hashtable table = new Hashtable();
        ArrayList list = new ArrayList();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter username: ");
            string user = Console.ReadLine();
            Console.Write("Enter role: ");
            string role = Console.ReadLine();
            table[user] = role;
            list.Add(user);
            list.Add(role);
            list.Add(i); // mixed type
        }
        Console.WriteLine("Hashtable Data:");
        foreach (DictionaryEntry d in table)
            Console.WriteLine($"{d.Key} -> {d.Value}");
        Console.WriteLine("ArrayList Data (Mixed Types):");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Risk: No type safety in ArrayList.");
    }
}