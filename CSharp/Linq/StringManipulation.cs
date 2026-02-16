using System;
using System.Linq;
public class StringManipulation
{
	public static void main()
	{
		List<string> list = new List<string>
		{
			"Mari",
			"Shiva",
			"Arjun",
			"Daniel",
			"University"
		};
		Console.WriteLine(list.Count());
		list.Where(l => l.Length > 4).ToList().ForEach(x => Console.Write(x + " "));
		Console.WriteLine();
		list.Where(l => l.StartsWith("A")).ToList().ForEach(x => Console.Write(x + " "));
        Console.WriteLine();
        list.Select(l => l.Substring(0, Math.Min(2, l.Length))).ToList().ForEach(x => Console.Write(x + " "));
    }
}