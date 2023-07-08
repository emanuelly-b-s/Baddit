using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;

namespace Back.Repositories;

public interface IRoleRepository
{
    Task<bool> ExistingRole(string nameRole);
    Task AddRole(Role role, List<int> permissions);
}
