using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class UpvoteDownvote
{
    public int Id { get; set; }

    public int? Participant { get; set; }

    public int? Post { get; set; }

    public virtual UserBaddit? ParticipantNavigation { get; set; }

    public virtual Post? PostNavigation { get; set; }
}
