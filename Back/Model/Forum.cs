using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Forum
{
    public int Id { get; set; }

    public string? Creator { get; set; }

    public string ForumName { get; set; } = null!;

    public string DescriptionForum { get; set; } = null!;

    public virtual UserBaddit? CreatorNavigation { get; set; }

    public virtual ICollection<ParticipantForum> ParticipantForums { get; set; } = new List<ParticipantForum>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
