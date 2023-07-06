using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Back.Model;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositories;
public class RoleRepository : IRoleRepository
{

    private readonly BadditContext ctx;
    public RoleRepository(BadditContext ctx) => this.ctx = ctx;
    public async Task Add(Role obj)
    {
        ctx.Add(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task AddPermission(Permission permission)
    {
        ctx.Add(permission);
        await ctx.SaveChangesAsync();   
    }

    public Task Delete(Role obj)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistingRole(string nameRole)
        => await ctx.Roles
                    .AnyAsync(r => r.RoleName == nameRole);

    public Task<List<Role>> Filter(Expression<Func<Role, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task Update(Role obj)
    {
        throw new NotImplementedException();
    }

}
