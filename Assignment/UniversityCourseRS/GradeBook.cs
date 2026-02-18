using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourseRS
{
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }
    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; } // Prerequisite
    }
    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<(TStudent, TCourse), double> _grades = new();
        private EnrollmentSystem<TStudent, TCourse> _enrollment;
        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
        {
            _enrollment = enrollment;
        }
        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");
            if (!_enrollment.GetEnrolledStudents(course)
                .Any(s => s.StudentId == student.StudentId))
                throw new InvalidOperationException("Student not enrolled in course.");
            _grades[(student, course)] = grade;
        }
        public double? CalculateGPA(TStudent student)
        {
            var studentGrades = _grades
                .Where(g => g.Key.Item1.StudentId == student.StudentId)
                .ToList();
            if (!studentGrades.Any())
                return null;
            double total = 0;
            int totalCredits = 0;
            foreach (var entry in studentGrades)
            {
                total += entry.Value * entry.Key.Item2.Credits;
                totalCredits += entry.Key.Item2.Credits;
            }
            return total / totalCredits;
        }
        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var courseGrades = _grades
                .Where(g => g.Key.Item2.CourseCode == course.CourseCode)
                .ToList();
            if (!courseGrades.Any())
                return null;
            var top = courseGrades.OrderByDescending(g => g.Value).First();
            return (top.Key.Item1, top.Value);
        }
    }
}
