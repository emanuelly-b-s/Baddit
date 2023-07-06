using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;
using Back.Repositories.ForumRep;
using Back.Repositories.User;

namespace Back.Repositories.PostRep;

public class UpDownRepository : IUpDownRepository
{
    private readonly BadditContext ctx;
    private readonly IForumRepository<Forum> _forumRepository;
    private readonly IUserRepository<UserBaddit> _userRepo;

    public UpDownRepository(BadditContext ctx, IForumRepository<Forum> _forumRepository)
    {
        this.ctx = ctx;
        this._forumRepository = _forumRepository;
        this._userRepo = _userRepo;
    }

    public async Task Add(UpvoteDownvote upDown)
    {
        ctx.UpvoteDownvotes.Add(upDown);
        await ctx.SaveChangesAsync();
    }

    public int CountUpvote(InfoPostDTO post)
    {
        var posts = ctx.UpvoteDownvotes
                    .Where(up => up.Post == post.Id)
                    .Count();

        return posts;
    }

    public Task Delete(UpvoteDownvote obj)
    {
        throw new NotImplementedException();
    }

    public Task<List<Post>> Filter(Expression<Func<Post, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task<List<UpvoteDownvote>> Filter(Expression<Func<UpvoteDownvote, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpvoteDownvote obj)
    {
        throw new NotImplementedException();
    }
}
