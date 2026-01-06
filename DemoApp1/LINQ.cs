using System.Linq;
class Student1
{
    public string? Name;
    public int marks;
}
class LINQ
{
    public static void main()
    {
        int[] numbers={47,64,32,2,55,54};
        // var evenNumbers=numbers.Where(n=>n%2==0);
        // Console.WriteLine(evenNumbers.GetType());
        // Console.WriteLine("Even numbers are:");
        // foreach(var n in evenNumbers)
        // {
        //     Console.WriteLine(n);
        // }
        // var result=numbers.Where(n=>n>3).Select(n=>n*3);
        // foreach(var n in result)
        // {
        //     Console.Write(n+" ");
        // }

        var ascen=numbers.OrderBy(n=>n);
        var desc=numbers.OrderByDescending(n=>n);
        foreach(var n in ascen)
        {
            Console.Write(n+" ");
        }
        foreach(var n in desc)
        {
            Console.Write(n+" ");
        }
        Student1[] students =
        {
            new Student1{Name="Raman",marks=45},
            new Student1{Name="Sandeep",marks=75},
            new Student1{Name="Amit",marks=56}
        };
        var asend=students.OrderBy(s=>s.marks);
        foreach(var n in asend)
        {
            Console.Write(n+" ");
        }
        var result=students.Select(s=>new
        {
            s.Name,Grade=s.marks>60?"Pass":"Fail"
        });
        Console.WriteLine(result.GetType());
        result=result.ToList();
        Console.WriteLine(result.GetType());
    }
}