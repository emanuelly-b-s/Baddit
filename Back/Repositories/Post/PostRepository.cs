using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;

namespace Back.Repositories.PostRep;

public class PostRepository : IPostRepository<Post>
{
    private readonly BadditContext ctx;
    public async Task AddPost(Post post)
    {
        await ctx.Posts.AddAsync(post);
        await ctx.SaveChangesAsync();
    }
}
