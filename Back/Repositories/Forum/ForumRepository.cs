using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using Back.Repositories;
using DTO;

namespace Back.Repositories.ForumRep;

public class ForumRepository : IForumRepository<Forum>
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public Task<List<Forum>> GetAll(Forum ctx)
    {
        throw new NotImplementedException();
    }

    public Task<List<Forum>> GetParticipants(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddUser(ListParticipantsForum obj)
    {
        await ctx.ListParticipantsForums.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Forum>> GetAllForums()
    {
       var forumsTake = ctx.Forums.Take(20);

        var forums = await forumsTake.ToListAsync();

       return forums;
    }
}