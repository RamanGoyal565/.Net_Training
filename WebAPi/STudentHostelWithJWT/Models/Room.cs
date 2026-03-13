namespace StudentHostelWithJWT.Models;

public class Room
{
    public int Id { get; set; }

    public string RoomNumber { get; set; }

    public Student Student { get; set; } 
}
