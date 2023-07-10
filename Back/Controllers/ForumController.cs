using Back.Model;
using Back.Repositories;
using Back.Repositories.ForumRep;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("forum")]
public class ForumController : ControllerBase
{
    [HttpPost("new-forum")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Register(
        [FromServices] IForumRepository forumRep,
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
        [FromBody] InfoForum forumData,
        [FromServices] IForumRepository forumRep
    )
    {
        Forum forum = await forumRep.GetForumById(forumData.ID);

        if (forumData is null)
            return NotFound();


        InfoForum result = new()
        {
            ID = forum.Id,
            Creator = forum.Creator,
            ForumName = forum.ForumName,
            DescriptionForum = forum.DescriptionForum
        };

        return Ok(result);

    }

    [HttpGet]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<List<Forum>>> GetAll(
        [FromServices] IForumRepository forumRepo
    )
    {
        var query = await forumRepo.Filter(f => true);
        return query;
    }

    [HttpPost("addUser")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> AddUser(
       [FromServices] IForumRepository forumRep,
       [FromBody] ListUserOnForum data
    )
    {

        var isMember = await forumRep.IsMember(data.Participant, data.Forum);

        if (isMember)
            return BadRequest();

        ListParticipantsForum newUser = new()
        {
            ParticipantId = data.Participant,
            ForumId = data.Forum,
        };

        await forumRep.AddUser(newUser);

        return Ok();

    }

    [HttpPost("removeUser")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> RemoveUser(
       [FromServices] IForumRepository forumRep,
       [FromBody] ListParticipantsForum data
    )
    {
        await forumRep.RemoveUser(data);

        return Ok();

    }

    [HttpPost("getAllForums")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<IEnumerable<Forum>>> GetAllForums(
        [FromServices] IForumRepository forumRepo
    )
    {
        var forums = await forumRepo.GetAllForums();

        return Ok(forums);
    }

    [HttpPost("searchForum")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<List<Forum>>> SearchForum(
        [FromServices] IForumRepository forumRepo,
        [FromBody] string forum
    )
    {
        var forums = await forumRepo.Search(forum);

        return Ok(forums);
    }

    [HttpPost("getAllMembers")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<List<ParticipantForum>>> GetGroupMembers(
        [FromServices] IForumRepository forumRepo,
        [FromBody] InfoForum forum
    )
    {
        var users = await forumRepo.GetGroupMembers(forum);

        return Ok(users);
    }


}



