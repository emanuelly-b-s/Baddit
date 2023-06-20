using System;
using System.Collections.Generic;

namespace Model;

public partial class LikeDislaike
{
    public int Id { get; set; }

    public string? ParticipantLikeDislaike { get; set; }

    public int? PostLikeDislaike { get; set; }

    public virtual UserDittopium? ParticipantLikeDislaikeNavigation { get; set; }

    public virtual Post? PostLikeDislaikeNavigation { get; set; }
}
