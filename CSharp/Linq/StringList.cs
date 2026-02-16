using System;
using System.Collections;
using System.Text;

public class StringList
{
    public static void main()
    {
        IEnumerable list = new ArrayList { 1, "Raman", "BTech", 2000, 30 };
        var result = list.OfType<int>();
        foreach(var i in result)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();
        IEnumerable<string> names = new List<String> { "Satyam", "Aakash", "Ramanv", "Aksh", "Shubhamv", "Aryan", "Ankit" };
        var result2 = names.Where(n => n.StartsWith("A"));
        var result3=names.Where(n => n.EndsWith("v")).Select(n=>"Mr. "+n);
        foreach (var i in result2)
            Console.Write(i + " ");
        Console.WriteLine();
        foreach (var i in result3)
            Console.Write(i+" ");
    }
}