using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Permission
{
    public int Id { get; set; }

    public string? PermissionName { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
