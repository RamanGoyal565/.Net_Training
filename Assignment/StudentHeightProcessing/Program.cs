using System.Collections;

namespace StudentHeightProcessing
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public float? Height {  get; set; }
        public float AttendancePercetage {  get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student{Id=1,Name="Raman",Height=165.6f,AttendancePercetage=75.5f},
                new Student{Id=2,Name="Satyam",Height=175.6f,AttendancePercetage=74.5f},
                new Student{Id=3,Name="Vasudev",Height=null,AttendancePercetage=85.5f},
                new Student{Id=4,Name="Rachit",Height=155.6f,AttendancePercetage=65.5f},
            };
            ArrayList arrayList = new ArrayList();
            foreach(var s in students)
            {
                arrayList.Add(new ArrayList { s.Id,s.Name,s.Height,s.AttendancePercetage });
            }
            
        }
    }
}