using System;

public class DefferedExecution
{
	public static void main()
	{
		List<int> numbers = new List<int> { 10, 20, 30 };
		IEnumerable<int> querry = numbers.Where(n => n > 15);
		numbers.Add(40);
		foreach(var n in querry)
			Console.WriteLine(n);

		var immediateQuerry= numbers.Where(n => n > 15).ToList();
        numbers.Add(50);
        foreach (var n in immediateQuerry)
            Console.WriteLine(n);
    }
}
