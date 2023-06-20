using System;
using System.Collections.Generic;

namespace Model;

public partial class Position
{
    public int Id { get; set; }

    public string? PositionName { get; set; }

    public bool? Comment { get; set; }

    public bool? Likes { get; set; }

    public bool? Dislike { get; set; }

    public virtual ICollection<ParticipantForum> ParticipantForums { get; set; } = new List<ParticipantForum>();
}
