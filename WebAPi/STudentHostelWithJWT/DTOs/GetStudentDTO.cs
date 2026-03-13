namespace StudentHostelWithJWT.DTOs
{
    public class StudentWithRoomDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public int? RoomId { get; set; }

        public string? RoomNumber { get; set; }
    }
}
