using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repositories;

public interface IRoleRepository<Role> : IRepository<Role>
{
    Task<bool> ExistingRole(string nameRole);
}
