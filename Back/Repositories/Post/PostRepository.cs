using System.Linq.Expressions;
using Back.Model;
using Microsoft.EntityFrameworkCore;
using DTO;
using Back.Repositories.ForumRep;
using Back.Repositories.User;

namespace Back.Repositories.PostRep;

public class PostRepository : IPostRepository
{
    private readonly BadditContext ctx;
    private readonly IForumRepository _forumRepository;
    private readonly IUserRepository _userRepo;

    public PostRepository(BadditContext ctx, IForumRepository _forumRepository)
    {
        this.ctx = ctx;
        this._forumRepository = _forumRepository;
        this._userRepo = _userRepo;
    }


    public async Task Add(Post obj)
    {
        await ctx.Posts.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAllPostForum(int idForum)
    {
        var post = ctx.Posts
            .Where(postForum => postForum.Forum == idForum);


        var getPosts = await post.Take(10)
                                 .ToListAsync();

        return getPosts;
    }



    public async Task<IEnumerable<Post>> GetPostsForUser(int idUser)
    {

        var users = ctx.ListParticipantsForums.Where(u => u.Id == idUser);

        var userOnForum = ctx.UserBaddits.Join(ctx.ListParticipantsForums,
                                        user => user.Id,
                                        userList => userList.ParticipantId,
                                        (user, forumList) => new
                                        {
                                            forums = forumList.ForumId,
                                            userId = forumList.ParticipantId
                                        })
                                        .Where(u => u.userId == idUser);



        var getPostsForUser = ctx.Posts.Join(userOnForum,
                                    post => post.Forum,
                                    f => f.forums,
                                    (post, f)
                                        => post);

        var listPosts = await getPostsForUser.ToListAsync();

        return listPosts;
    }

    public Task UpdateUpDown(InfoPostDTO post)
    {
        throw new NotImplementedException();
    }

    public int CountUpvote(InfoPostDTO post)
    {
        var posts = ctx.UpvoteDownvotes
                    .Where(up => up.Post == post.Id)
                    .Count();

        return posts;
    }

    public Task<List<Post>> Filter(Expression<Func<Post, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Post obj)
    {
        ctx.Posts.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Post obj)
    {
        ctx.Posts.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Post>> GetPostsFeed()
    {
        var posts = ctx.Posts.Take(20);
        var listPosts = await posts.ToListAsync();

        return listPosts;
    }
}
