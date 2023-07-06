using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Back.Model;

namespace Back.Repositories;

public class PermissionRoleRepository : IRepository<Permission>
{

    private readonly BadditContext ctx;

    public PermissionRoleRepository(BadditContext ctx) => this.ctx = ctx;

    public Task Add(Permission obj)
    {
        throw new NotImplementedException();
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