using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using Back.Repositories;

namespace Back.Repositories.ForumRep;

public class ForumRepository : IForumRepository<Forum>
{
    private BadditContext ctx;

    public ForumRepository(BadditContext ctx) => this.ctx = ctx;

    // public async Task<Forum> GetByName(int id) 
    //     =>  await ctx.Forums.Where(f => f.Id == id)
    //                         .FirstOrDefaultAsync();

    public async Task<bool> ExistingForum(string forumName)
        => await ctx.Forums
                    .AnyAsync(f => f.ForumName == forumName);


    public async Task Add(Forum obj)
    {
        await ctx.Forums.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public void Delete(Forum obj)
    {
        throw new NotImplementedException();
    }


    public Task<List<Forum>> Filter(Expression<Func<Forum, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public void Update(Forum obj)
    {
        throw new NotImplementedException();
    }
}