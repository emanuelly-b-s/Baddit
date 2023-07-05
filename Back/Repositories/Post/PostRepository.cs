using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;
using Back.Repositories.ForumRep;

namespace Back.Repositories.PostRep;

public class PostRepository : IPostRepository<Post>
{
    private readonly BadditContext ctx;
    private readonly IForumRepository<Forum> _forumRepository;
    public PostRepository(BadditContext ctx, IForumRepository<Forum> _forumRepository)
    {
        this.ctx = ctx;
        this._forumRepository = _forumRepository;
    }


    public async Task AddPost(Post obj)
    {
        await ctx.Posts.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAllPost(int idForum)
    {
        var post = ctx.Posts
            .Where(postForum => postForum.Forum == idForum);


        var getPosts = await post.Take(10)
                                 .ToListAsync();

        return getPosts;
    }

    public async Task UpdateUpDown(InfoPostDTO post)
    {
        var postUpdate = await ctx.Posts
                                        .Where(postForum => postForum.Id == post.Id)
                                        .FirstOrDefaultAsync();

        ctx.Posts.Update(postUpdate);
        await ctx.SaveChangesAsync();
    }
}
