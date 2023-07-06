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
        [FromServices] IPostRepository<Post> postRepo,
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

    [HttpPost("getPosts")]
    [EnableCors("MainPolicy")]

    public async Task<ActionResult<IEnumerable<Post>>> GetPosts(
        [FromServices] IPostRepository<Post> postRepo,
        [FromBody] InfoForum infoForum
    )
    {
        var posts = await postRepo.GetAllPost(infoForum.ID);

        if(posts.Count < 0)
            return BadRequest();

        return Ok(posts);
    } 

}
