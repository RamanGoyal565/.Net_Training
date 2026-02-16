using System;

public class InnerJoin
{
	public static void main()
	{
		List<Student> students = new List<Student>()
		{
			new Student { StudentId = 1, Name = "Raman" },
			new Student { StudentId = 2, Name = "Rachit" },
			new Student { StudentId = 3, Name = "Vasudev" }
		};
		List<Course> courses = new List<Course>()
		{
			new Course{StudentId=1,CourseName="C#"},
			new Course{StudentId=1,CourseName="SQL"},
			new Course{StudentId=2,CourseName=".NET"}
		};
		var result = from s in students
					 join c in courses
					 on s.StudentId equals c.StudentId
					 select new
					 {
						 StudentName = s.Name,
						 CourseName = c.CourseName
					 };
		foreach(var r in result)
		{
			Console.WriteLine(r.StudentName+" - "+r.CourseName);
		}
	}
}
class Student
{
	public int StudentId { get; set; }
	public string Name { get; set; }
}
class Course
{
	public int StudentId { get; set; }
	public string CourseName { get; set; }
}
