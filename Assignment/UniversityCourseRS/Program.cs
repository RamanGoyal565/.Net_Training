using UniversityCourseRS;
class Program
{
    static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var s1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3 };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 1 };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 4 };
        var c1 = new LabCourse
        {
            CourseCode = "LAB101",
            Title = "Basic Lab",
            MaxCapacity = 2,
            Credits = 3,
            RequiredSemester = 2
        };
        var c2 = new LabCourse
        {
            CourseCode = "LAB201",
            Title = "Advanced Lab",
            MaxCapacity = 1,
            Credits = 4,
            RequiredSemester = 3
        };
        // Successful enrollment
        enrollment.EnrollStudent(s1, c1);
        // Prerequisite failure
        enrollment.EnrollStudent(s2, c1);
        // Capacity failure
        enrollment.EnrollStudent(s3, c1);
        enrollment.EnrollStudent(s3, c1);
        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);
        gradeBook.AddGrade(s1, c1, 90);
        gradeBook.AddGrade(s3, c1, 85);
        Console.WriteLine("Alice GPA: " + gradeBook.CalculateGPA(s1));
        var top = gradeBook.GetTopStudent(c1);
        Console.WriteLine($"Top student: {top?.student.Name} - {top?.grade}");
    }
}