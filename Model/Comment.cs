using System;
using System.Collections.Generic;

namespace Model;

public partial class Comment
{
    public int Id { get; set; }

    public string? ParticipantComment { get; set; }

    public int? PostComment { get; set; }

    public string CommentText { get; set; } = null!;

    public virtual UserDittopium? ParticipantCommentNavigation { get; set; }

    public virtual Post? PostCommentNavigation { get; set; }
}
