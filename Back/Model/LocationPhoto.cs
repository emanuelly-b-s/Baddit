using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class LocationPhoto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? Photo { get; set; }

    public int? Participant { get; set; }

    public virtual UserBaddit? ParticipantNavigation { get; set; }

    public virtual ImageDatum? PhotoNavigation { get; set; }
}
