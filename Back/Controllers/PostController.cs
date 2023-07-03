using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using Back.Repositories.PostRep;
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
        [FromBody] Post post
        )
        {
            Post newPost = new Post()
            {
                Tittle = post.Tittle,
                PostText = post.PostText,
                PostDate = post.PostDate,
                Forum = post.Forum,
                Participant = post.Participant
            };

            await postRepo.AddPost(newPost);

        return Ok();
        }
}
