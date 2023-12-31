﻿using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class UserBaddit
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateBirth { get; set; }

    public string NickUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string SaltPassword { get; set; } = null!;

    public int? UserPhoto { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Forum> Forums { get; set; } = new List<Forum>();

    public virtual ICollection<ListParticipantsForum> ListParticipantsForums { get; set; } = new List<ListParticipantsForum>();

    public virtual ICollection<LocationPhoto> LocationPhotos { get; set; } = new List<LocationPhoto>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<UpvoteDownvote> UpvoteDownvotes { get; set; } = new List<UpvoteDownvote>();

    public virtual ImageDatum? UserPhotoNavigation { get; set; }
}
