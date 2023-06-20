using System;
using System.Collections.Generic;

namespace Model;

public partial class Post
{
    public int Id { get; set; }

    public string Tittle { get; set; } = null!;

    public string PostText { get; set; } = null!;

    public int? Likes { get; set; }

    public int? Dislike { get; set; }

    public int? Comment { get; set; }

    public DateTime PostDate { get; set; }

    public int? Forum { get; set; }

    public string? PostParticipant { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Forum? ForumNavigation { get; set; }

    public virtual ICollection<LikeDislaike> LikeDislaikes { get; set; } = new List<LikeDislaike>();

    public virtual ICollection<LocationPhoto> LocationPhotos { get; set; } = new List<LocationPhoto>();

    public virtual UserDittopium? PostParticipantNavigation { get; set; }
}
