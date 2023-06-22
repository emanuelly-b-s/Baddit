using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Post
{
    public int Id { get; set; }

    public string Tittle { get; set; } = null!;

    public string PostText { get; set; } = null!;

    public DateTime PostDate { get; set; }

    public int? Forum { get; set; }

    public int? Participant { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Forum? ForumNavigation { get; set; }

    public virtual UserBaddit? ParticipantNavigation { get; set; }

    public virtual ICollection<UpvoteDownvote> UpvoteDownvotes { get; set; } = new List<UpvoteDownvote>();
}
