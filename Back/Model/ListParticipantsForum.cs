using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class ListParticipantsForum
{
    public int Id { get; set; }

    public int? ForumId { get; set; }

    public int? ParticipantId { get; set; }

    public int? RoleId { get; set; }

    public virtual Forum? Forum { get; set; }

    public virtual UserBaddit? Participant { get; set; }

    public virtual Role? Role { get; set; }
}
