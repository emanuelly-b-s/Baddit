using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;

namespace Back.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly BadditContext ctx;

    public UserRepository(BadditContext ctx) => this.ctx = ctx;

    public async Task<bool> ExistingEmail(string userNickName)
        => await ctx.UserBaddits
                    .AnyAsync(u => u.NickUser == userNickName);

    public async Task<bool> ExistingNickName(string userEmail)
    => await ctx.UserBaddits
                .AnyAsync(u => u.Email == userEmail);

    public async Task Add(UserBaddit obj)
    {
        await ctx.UserBaddits.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(UserBaddit obj)
    {
        ctx.UserBaddits.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<UserBaddit>> Filter(Expression<Func<UserBaddit, bool>> condition)
    {
        return await ctx.UserBaddits
            .Where(condition)
            .ToListAsync();
    }

    public async Task Update(UserBaddit obj)
    {
        ctx.UserBaddits.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<UserBaddit> GetUserByID(int id)
    {
        var user = await ctx.FindAsync<UserBaddit>(id);
        return user;
    }

    public async Task<InfoUser> GetUserByName(string userName)
    {
        var user = await ctx.FindAsync<InfoUser>(userName);
        return user;
    }

    public async Task<IEnumerable<Forum>> GetGroups(int id)
    {
        var groups = ctx.UserBaddits.Join(ctx.ListParticipantsForums,
            u => u.Id,
            listGroups => listGroups.ParticipantId,
            (u, listGroups) => new
            {
                idUser = u.Id,
                listGroupsId = listGroups.ForumId
            })
            .Where(x => x.idUser == id)
            .Join(ctx.Forums,
                listGroups => listGroups.listGroupsId,
                groups => groups.Id,
                (listGroups, forum)
                => forum);

        var forums = await groups.ToListAsync();

        return forums;
    }

}

