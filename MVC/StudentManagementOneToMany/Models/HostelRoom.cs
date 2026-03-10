namespace StudentManagementOneToMany.Models
{
    public class HostelRoom
    {
        public int HostelRoomId { get; set; }

        public int RoomNumber { get; set; }

        public int Capacity { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
