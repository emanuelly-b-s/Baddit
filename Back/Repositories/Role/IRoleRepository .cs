using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;

namespace Back.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<bool> ExistingRole(string nameRole);
}
