using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Back.Model;

namespace Back.Repositories;

public class PermissionRoleRepository : IRepository<RolePermission>
{

    private readonly BadditContext ctx;

    public PermissionRoleRepository(BadditContext ctx) => this.ctx = ctx;

    public async Task Add(RolePermission obj)
    {
        ctx.RolePermissions.Add(obj);
        await ctx.SaveChangesAsync();
    }

    public Task Delete(RolePermission obj)
    {
        throw new NotImplementedException();
    }

    public Task<List<RolePermission>> Filter(Expression<Func<RolePermission, bool>> condition)
    {
        throw new NotImplementedException();
    }


    public Task Update(RolePermission obj)
    {
        throw new NotImplementedException();
    }
}
  