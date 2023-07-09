using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public int? Forum { get; set; }

    public virtual Forum? ForumNavigation { get; set; }

    public virtual ICollection<ListParticipantsForum> ListParticipantsForums { get; set; } = new List<ListParticipantsForum>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
