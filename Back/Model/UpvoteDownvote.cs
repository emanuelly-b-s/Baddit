using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class UpvoteDownvote
{
    public int Id { get; set; }

    public int? ParticipantId { get; set; }

    public int? PostId { get; set; }

    public virtual UserBaddit? Participant { get; set; }

    public virtual Post? Post { get; set; }
}
