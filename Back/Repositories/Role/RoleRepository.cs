using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Back.Model;
using DTO;
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

    public async Task AddRole(Role role, List<int> permissions)
    {
        ctx.Roles.Add(role);
        await ctx.SaveChangesAsync();

        foreach (var permission in permissions)
        {
            await ctx.RolePermissions.AddAsync(new RolePermission()
            {
                RoleId = role.Id,
                PermissionId = permission,
            });
        }

        await ctx.SaveChangesAsync();
    }


    public async Task Delete(Role obj)
    {
        ctx.Roles.Remove(obj);
        await ctx.SaveChangesAsync();
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


    public void GetUserForum(InfoForum forum)
    {
        var userForum = ctx.UserBaddits
                        .Include(l => l.ListParticipantsForums)
                        .ToListAsync();


        Console.WriteLine(userForum);
    }

  

    public async Task<Role> Find(int id)
    {
        var role = await ctx.Roles.Include(r => r.Forum)
                                       .FirstAsync(r => r.Id == id);
        return role;
    }


}
