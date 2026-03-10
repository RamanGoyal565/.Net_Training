using System;
using System.Collections.Generic;

namespace StudentHostel.Models;

public partial class Hostel
{
    public int HostelId { get; set; }

    public string? RoomNumber { get; set; }

    public string? Block { get; set; }

    public virtual Student? Student { get; set; }
}
