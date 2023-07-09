using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class ListParticipantsForum
{
    public int Id { get; set; }

    public int? Forum { get; set; }

    public int? Participant { get; set; }

    public int? CargoUser { get; set; }

    public virtual Role? CargoUserNavigation { get; set; }

    public virtual Forum? ForumNavigation { get; set; }

    public virtual UserBaddit? ParticipantNavigation { get; set; }
}
