using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Back.Model;

namespace Back.Repositories;
public class RoleRepository : IRoleRepository<Role>
{

    private readonly BadditContext ctx;
    public RoleRepository(BadditContext ctx) => this.ctx = ctx;
    public async Task Add(Role obj)
    {
        ctx.Add(obj);
        await ctx.SaveChangesAsync();
    }

    public Task Delete(Role obj)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistingRole(string nameRole)
    {
        throw new NotImplementedException();
    }

    public Task<List<Role>> Filter(System.Linq.Expressions.Expression<Func<Role, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task Update(Role obj)
    {
        throw new NotImplementedException();
    }


}
