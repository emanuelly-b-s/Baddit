using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Comment
{
    public int Id { get; set; }

    public int? Participant { get; set; }

    public int? PostComment { get; set; }

    public string CommentText { get; set; } = null!;

    public virtual UserBaddit? ParticipantNavigation { get; set; }

    public virtual Post? PostCommentNavigation { get; set; }
}
