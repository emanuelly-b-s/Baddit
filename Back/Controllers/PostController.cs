using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using Back.Repositories.PostRep;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Back.Controllers;

[Route("forum/post")]
public class PostController : ControllerBase
{
    [HttpPost("new-post")]
    [EnableCors("MainPolicy")]
    public async Task<IActionResult> AddPost(
        [FromServices] IPostRepository postRepo,
        [FromBody] NewPostDTO post
        )
    {
        Post newPost = new()
        {
            Tittle = post.Tittle,
            PostText = post.PostText,
            PostDate = post.PostDate,
            Forum = post.Forum,
            Participant = post.Participant
        };

        await postRepo.Add(newPost);

        return Ok();
    }

    [HttpPost("getPostsForum")]
    [EnableCors("MainPolicy")]

    public async Task<ActionResult<IEnumerable<Post>>> GetAllPostForum(
        [FromServices] IPostRepository postRepo,
        [FromBody] InfoForum infoForum
    )
    {
        var posts = await postRepo.GetAllPostForum(infoForum.ID);

        if (posts.Count < 0)
            return BadRequest();

        return Ok(posts);
    }

    [HttpPost("getPostsUser")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPostsForUser(
        [FromServices] IPostRepository postRepo,
        [FromBody] InfoUser userData
    )
    {   
        var listPost = await postRepo.GetPostsForUser(userData.UserId);

        return Ok(listPost);
    }

    [HttpGet("getPostsFeed")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<List<Post>>> GetPostsFeed(
        [FromServices] IPostRepository postRepo
    )
    {   
        // var idUSer = userData.UserId;

        var listPost = await postRepo.GetPostsFeed();

        return Ok(listPost);
    }

}
