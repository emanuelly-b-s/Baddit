using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;

namespace Back.Repositories.PostRep;

public class PostRepository : IPostRepository<Post>
{
    private readonly BadditContext ctx;
    public PostRepository(BadditContext ctx)
        => this.ctx = ctx;

    public async Task AddPost(Post obj)
    {
        await ctx.Posts.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }
}
