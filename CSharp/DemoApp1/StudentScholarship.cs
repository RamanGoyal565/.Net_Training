namespace Student11{
    public delegate bool IsEligibleforScholarship(Student std);
    public class Student
    {
        public int RollNo{get;set;}
        public string Name{get;set;}
        public int Marks{get;set;}
        public char SportsGrade{get;set;}
        public static string GetEligibleStudents(List<Student> studentList,
        IsEligibleforScholarship isEligible)
        {
            string ans="";
            foreach(Student i in studentList)
            {
                if(isEligible(i))
                    ans+=i.Name+", ";
            }
            return ans;
        }
    }
    class Program
    {
        public static bool ScholarEligibility(Student std)
        {
            if(std.Marks>80&&std.SportsGrade=='A')
                return true;
            return false;
        }
        static void main()
        {
            
        }
    }
}