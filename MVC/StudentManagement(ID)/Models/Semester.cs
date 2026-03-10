namespace StudentManagement_ID_.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double GPA { get; set; }
        public Student Students { get; set; }
    }
}
