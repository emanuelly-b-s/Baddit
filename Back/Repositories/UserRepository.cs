using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;

using Back.Model;

public class UserRepository : IRepository<UserBaddit>
{
    private BadditContext ctx;

    public UserRepository(BadditContext ctx) => this.ctx = ctx;

    public async Task Add(UserBaddit obj)
    {
        await ctx.UserBaddits.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public void Delete(UserBaddit obj)
    {
        ctx.UserBaddits.Remove(obj);
        ctx.SaveChangesAsync();
    }

    public async Task<List<UserBaddit>> Filter(Expression<Func<UserBaddit, bool>> condition)
    {
        return await ctx.UserBaddits
            .Where(condition)
            .ToListAsync();
    }

    public void Update(UserBaddit obj)
    {
        ctx.UserBaddits.Update(obj);
    }

}