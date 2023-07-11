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
        var upDown = ctx.UpvoteDownvotes.Include(p => p.Post)
                                        .Select(posts => new Post
                                        {
                                            Id = posts.Post.Id,
                                            Tittle = posts.Post.Tittle,
                                            PostDate = posts.Post.PostDate,
                                            Forum = posts.Post.Forum,
                                            Participant = posts.Post.Participant,
                                            PostText = posts.Post.PostText,
                                            Upvote = ctx.UpvoteDownvotes
                                                        .Where(p => p.PostId == posts.Post.Id)
                                                        .Count()
                                        }

                                        );

        var listPosts = await upDown.ToListAsync();

        return listPosts;
    }

    public async Task<List<Post>> GetAllPostForum(int idForum)
    {
        var post = ctx.Posts.Include(p => p.UpvoteDownvotes)
                            .Select(post => new Post
                            {
                                Tittle = post.Tittle,
                                PostText= post.PostText,
                                PostDate = post.PostDate,
                                Forum = post.Forum,
                                Upvote = post.UpvoteDownvotes.Count()
                            })
                            .Where(f => f.Forum == idForum);

        // .Select(posts => new Post
        // {
        //     Tittle = posts.Post.Tittle,
        //     PostDate = posts.Post.PostDate,
        //     Forum = posts.Post.Forum,
        //     Participant = posts.Post.Participant,
        //     PostText = posts.Post.PostText,
        //     Upvote = ctx.UpvoteDownvotes
        //                 .Where(p => p.PostId == posts.Post.Id)
        //                 .Count()
        // });

        var getPosts = await post.Take(10)
                                 .ToListAsync();

        return getPosts;
    }
}
