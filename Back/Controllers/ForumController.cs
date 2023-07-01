using Back.Model;
using Back.Repositories.ForumRep;
using Back.Repositories.User;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UserServices;

namespace Back.Controllers;

[ApiController]
[Route("forum")]
public class ForumController : ControllerBase
{
    [HttpPost("/new-forum")]
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


    [HttpGet("{code}")]
    public async Task<ActionResult<Forum>> GetById(
        string code,
        [FromServices] IForumRepository<Forum> forumRep
    )
    {
        if (int.TryParse(code, out int id))
        {
            var query = await forumRep.Filter(f => f.Id == id);
            var forum = query.FirstOrDefault();

            if (forum is null)
                return NotFound();

            return forum;
        }

        return BadRequest("n deu boa");
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

}

