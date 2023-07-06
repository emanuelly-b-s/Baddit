using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using Back.Repositories;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("post/upDown")]
public class UpDownController : ControllerBase
{
    [HttpPost("upvotesDownvotes")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> AddUpDown(
        [FromServices] IUpDownRepository<UpvoteDownvote> postRepo,
        [FromBody] UpvoteDownvoteDTO up
    )
    {

        UpvoteDownvote upDown = new()
        {
            Participant = up.Participant,
            Post = up.Post
        };

        await postRepo.Add(upDown);

        return Ok();
    }



}
