using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;
using Back.Repositories.ForumRep;
using Back.Repositories.User;

namespace Back.Repositories.PostRep;

public class PostRepository : IPostRepository<Post>
{
    private readonly BadditContext ctx;
    private readonly IForumRepository<Forum> _forumRepository;
    private readonly IUserRepository<UserBaddit> _userRepo;

    public PostRepository(BadditContext ctx, IForumRepository<Forum> _forumRepository)
    {
        this.ctx = ctx;
        this._forumRepository = _forumRepository;
        this._userRepo = _userRepo;
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

    public Task<List<Post>> GetPostsFeed(int idUser)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUpDown(InfoPostDTO post)
    {
        throw new NotImplementedException();
    }

    public async Task UpDown(UpvoteDownvote upDown)
    {
        ctx.UpvoteDownvotes.Add(upDown);
        await ctx.SaveChangesAsync();
    }

}
