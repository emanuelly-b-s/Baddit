using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositories;
public class PermissionRepository : IPermissionRepository
{
    private readonly BadditContext ctx;
    public PermissionRepository(BadditContext ctx) => this.ctx = ctx;
    public async Task Add(Permission obj)
    {
        ctx.Add(obj);
        await ctx.SaveChangesAsync();   
    }

    public Task Delete(Permission obj)
    {
        throw new NotImplementedException();
    }

    public Task<List<Permission>> Filter(Expression<Func<Permission, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task Update(Permission obj)
    {
        throw new NotImplementedException();
    }
}