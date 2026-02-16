using System;
using System.Collections.Generic;

class LinqObject
{
    public static void main()
    {
        // Creating a List
        List<Student1> students = new List<Student1>();


        // Adding students
        students.Add(new Student1 { Id = 1, Name = "Ravi", Age = 20 });
        students.Add(new Student1 { Id = 2, Name = "Kumar", Age = 22 });
        students.Add(new Student1 { Id = 3, Name = "Priya", Age = 19 });

        Console.WriteLine("Total Students: " + students.Count);
        Console.WriteLine();

        // Accessing by index
        Console.WriteLine("First Student: " + students[0].Name);
        Console.WriteLine();

        // Updating student
        students[1].Age = 23;

        // Removing student
        students.RemoveAt(2);

        Console.WriteLine("After Update and Remove:");
        Console.WriteLine("Total Students: " + students.Count);
        Console.WriteLine();

        // Sorting list by Age
        students.Sort((s1, s2) => s1.Age.CompareTo(s2.Age));

        Console.WriteLine("Sorted by Age:");
        foreach (var student in students)
        {
            Console.WriteLine(student.Id + " - " + student.Name + " - " + student.Age);
        }

        Console.ReadLine();
    }
}
class Student1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}