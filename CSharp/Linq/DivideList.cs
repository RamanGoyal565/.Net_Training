using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
public class DivideList
{
    public static void main()
    {
        List<int> list = new List<int> {1,3,45,67,345,54,753,3,2,54,676 };
        var firstPart=list.Take(list.Count/2).ToList();
        var secondPart=list.Skip(list.Count/2).ToList();
        foreach( int part in firstPart)
            Console.Write(part+" ");
        Console.WriteLine();
        foreach( int part in secondPart)
            Console.Write(part+" ");
        foreach (var i in list.SkipWhile(n => n < 45))
            Console.WriteLine(i);
    }
}