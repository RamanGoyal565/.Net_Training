namespace StudentManagementOneToMany.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int HostelRoomId { get; set; }

        public HostelRoom AssignedRoom { get; set; }

        public Payment Payment { get; set; }
    }
}
