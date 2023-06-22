using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class ParticipantForum
{
    public int Id { get; set; }

    public int? Forum { get; set; }

    public int? ParticipantForum1 { get; set; }

    public virtual Forum? ForumNavigation { get; set; }

    public virtual UserBaddit? ParticipantForum1Navigation { get; set; }
}
