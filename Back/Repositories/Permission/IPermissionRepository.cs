using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using DTO;

namespace Back.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<PermissionDTO> GetPermission(int id);
}
