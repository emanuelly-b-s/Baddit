using System;
using System.Collections.Generic;

namespace Model;

public partial class LocationPhoto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? Photo { get; set; }

    public string? PostParticipant { get; set; }

    public int? PostPhoto { get; set; }

    public virtual ImageDatum? PhotoNavigation { get; set; }

    public virtual UserDittopium? PostParticipantNavigation { get; set; }

    public virtual Post? PostPhotoNavigation { get; set; }
}
