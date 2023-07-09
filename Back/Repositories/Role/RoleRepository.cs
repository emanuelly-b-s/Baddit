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

    public async Task<bool> HasPermission(UserBaddit user, Forum forum, Permissions permission)
    {
        var role = this.ctx.ListParticipantsForums
                        .First(userForum => userForum.Forum == forum.Id 
                                && userForum.Participant == user.Id);

        var perms = await this.ctx.RolePermissions
            // .Where(rp => rp.RoleId == role)
            .Select(r => r.Permission.Id)
            .ToListAsync();

        var hasPerm = perms.Contains((int)permission);

        return hasPerm;
    }

}
