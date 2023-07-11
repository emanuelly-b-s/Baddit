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
        [FromServices] IUpDownRepository upDownRepo,
        [FromBody] UpvoteDownvoteDTO up
    )
    {

        UpvoteDownvote upDown = new()
        {
            ParticipantId = up.Participant,
            PostId = up.Post
        };

        await upDownRepo.Add(upDown);

        return Ok();
    }


    [HttpPost("countUpvotesDownvotes")]
    [EnableCors("MainPolicy")]
    public int CountUpDown(
        [FromServices] IUpDownRepository upDownRepo,
        [FromBody] InfoPostDTO up
    )
    {
        var qtdUpvote = upDownRepo.CountUpvote();

        return qtdUpvote;
    }

}
