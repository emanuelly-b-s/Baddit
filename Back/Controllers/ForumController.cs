using Back.Model;
using Back.Repositories.ForumRep;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using UserServices;

namespace Back.Controllers;

[ApiController]
[Route("forum")]
public class ForumController : ControllerBase
{
    [HttpPost("new-forum")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Register(
        [FromServices] IForumRepository<Forum> forumRep,
        [FromBody] NewForumDTO forumData)

    {
        if (await forumRep.ExistingForum(forumData.ForumName))
            return BadRequest("Forum ja existe");

        Forum f = new()
        {
            Creator = forumData.Owner,
            ForumName = forumData.ForumName,
            DescriptionForum = forumData.DescriptionForum,

        };

        await forumRep.Add(f);

        return Ok();

    }


    [HttpPost("get-forum")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<Forum>> GetById(
        int id,
        [FromServices] IForumRepository<Forum> forumRep
    )
    {
        Forum forumData = await forumRep.GetForumById(id);

        if (forumData is null)
            return NotFound();


        InfoForum result = new()
        {
            ID = forumData.Id,
            Creator = forumData.Creator,
            ForumName = forumData.ForumName,
            DescriptionForum = forumData.DescriptionForum
        };

        return Ok(result);

    }

    [HttpGet]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<List<Forum>>> GetAll(
        [FromServices] IForumRepository<Forum> forumRepo
    )
    {
        var query = await forumRepo.Filter(f => true);
        return query;
    }

    [HttpPost("addUser")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> AddUser(
       [FromServices] IForumRepository<Forum> forumRep,
       [FromBody] AddUserOnForum data
    )
    {
        ListParticipantsForum newUser = new()
        {
            Participant = data.Participant,
            Forum = data.Forum,
        };

        await forumRep.AddUser(newUser);

        return Ok();

    }

    [HttpPost]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<IEnumerable<Forum>>> GetAllForums(
        [FromServices] IForumRepository<Forum> forumRepo
    )
    {
        var forums = await forumRepo.GetAllForums();

        return Ok(forums);
    }

}

