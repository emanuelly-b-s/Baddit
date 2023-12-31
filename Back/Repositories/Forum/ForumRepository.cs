using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using Back.Repositories;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Back.Repositories.ForumRep;

public class ForumRepository : IForumRepository
{
    private readonly BadditContext ctx;

    public ForumRepository(BadditContext ctx) => this.ctx = ctx;

    public async Task<bool> ExistingForum(string forumName)
        => await ctx.Forums
                    .AnyAsync(f => f.ForumName == forumName);


    public async Task Add(Forum obj)
    {
        await ctx.Forums.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(Forum obj)
    {
        ctx.Forums.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<Forum> GetForumById(int id)
    {
        var forum = await ctx.FindAsync<Forum>(id);
        return forum;
    }


    public Task<List<Forum>> Filter(Expression<Func<Forum, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Forum obj)
    {
        ctx.Forums.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public Task<List<Forum>> GetAll(Forum ctx)
    {
        throw new NotImplementedException();
    }

    public async Task AddUser(ListParticipantsForum obj)
    {
        await ctx.ListParticipantsForums.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }
    public async Task RemoveUser(ListParticipantsForum obj)
    {
        ctx.ListParticipantsForums.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<bool> IsMember(int user, int forum)
    {
        bool isMember = await ctx.ListParticipantsForums
                            .AnyAsync(f => f.ParticipantId == user && f.ForumId == forum);
        return isMember;
    }

    public async Task<List<Forum>> GetAllForums()
    {
        var forumsTake = ctx.Forums.Take(20);

        var forums = await forumsTake.ToListAsync();

        return forums;
    }

    public Task<bool> ExistingUserOnForum(int userID, int forumId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Forum>> Search(string forum)
    {
        var forumsSearch = ctx.Forums
                            .Where(f => f.ForumName
                            .Contains(forum));

        var listForumsSearch = await forumsSearch.ToListAsync();

        return listForumsSearch;
    }

    public async Task<Forum> FindForum(int id)
    {
        var forum = await ctx.Forums.FindAsync(id);
        return forum;
    }


    public async Task<List<ParticipantForum>> GetGroupMembers(InfoForum forum)
    {

        var users = ctx.ListParticipantsForums
                    .Include(uForum => uForum.Participant)
                    .Include(uForum => uForum.Role)
                    .Where(uForum => uForum.ForumId == forum.ID)
                    .Select(uForum => new ParticipantForum
                    {
                        Id = (int)uForum.ParticipantId,
                        Name = uForum.Participant.UserName,
                        RoleUser = uForum.Role.RoleName
                    });

        var listUsers = users.ToListAsync();

        return await listUsers;
    }

    public async Task RoleUserPromoter(Forum forum, UserBaddit user, Role role)
    {
        var userforum = await ctx.ListParticipantsForums
                            .FirstAsync(uF => uF.ParticipantId == user.Id && uF.ForumId == forum.Id);

        userforum.RoleId = role.Id;

        ctx.ListParticipantsForums.Update(userforum);
        await ctx.SaveChangesAsync();
    }
}