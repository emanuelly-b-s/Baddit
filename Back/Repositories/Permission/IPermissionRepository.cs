using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;

namespace Back.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    // Task AddPermission(Permission permission);
}
