using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourseRS
{
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }
    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }

    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<TCourse, List<TStudent>> _enrollments = new();
        public bool EnrollStudent(TStudent student, TCourse course)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();
            var students = _enrollments[course];
            // Capacity check
            if (students.Count >= course.MaxCapacity)
            {
                Console.WriteLine("Enrollment failed: Course at capacity.");
                return false;
            }
            // Already enrolled
            if (students.Any(s => s.StudentId == student.StudentId))
            {
                Console.WriteLine("Enrollment failed: Student already enrolled.");
                return false;
            }
            // Prerequisite check (only if LabCourse)
            if (course is LabCourse labCourse)
            {
                if (student.Semester < labCourse.RequiredSemester)
                {
                    Console.WriteLine("Enrollment failed: Semester prerequisite not met.");
                    return false;
                }
            }
            students.Add(student);
            Console.WriteLine("Enrollment successful.");
            return true;
        }
        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            if (!_enrollments.ContainsKey(course))
                return Array.Empty<TStudent>();
            return _enrollments[course].AsReadOnly();
        }
        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            return _enrollments
                .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
                .Select(e => e.Key);
        }
        public int CalculateStudentWorkload(TStudent student)
        {
            return GetStudentCourses(student).Sum(c => c.Credits);
        }
    }
}