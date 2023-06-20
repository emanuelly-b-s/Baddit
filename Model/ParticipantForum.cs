using System;
using System.Collections.Generic;

namespace Model;

public partial class ParticipantForum
{
    public int Id { get; set; }

    public int? Forum { get; set; }

    public string? ParticipantForum1 { get; set; }

    public int? PositionParticipant { get; set; }

    public virtual Forum? ForumNavigation { get; set; }

    public virtual UserDittopium? ParticipantForum1Navigation { get; set; }

    public virtual Position? PositionParticipantNavigation { get; set; }
}
