using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using Back.Repositories;
using Back.Repositories.ForumRep;
using Back.Repositories.User;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("forum/role")]
public class RoleController : ControllerBase
{
    [HttpPost("new-role")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Register(
        [FromServices] IRoleRepository roleRep,
        [FromBody] RoleDTO roleData)

    {
        if (await roleRep.ExistingRole(roleData.RoleName))
            return BadRequest("Cargo ja existe");

        Role r = new()
        {
            Forum = roleData.Forum,
            RoleName = roleData.RoleName
        };

        await roleRep.AddRole(r, roleData.Permissions);

        return Ok();
    }

    [HttpPost("roleMember")]
    public async Task<ActionResult> PromoteRole(
                    [FromBody] ParticipantForum userData,
                    [FromServices] IForumRepository forumRepo,
                    [FromServices] IRoleRepository roleRepo,
                    [FromServices] IUserRepository userRepo
    )
    {
        Forum forum = await forumRepo.FindForum(userData.IdForum);

        if (forum is null)
            return BadRequest();

        var role = await roleRepo.Find(userData.IdRole);

        if (role is null)
            return NotFound("n existe");

        var user = await userRepo.Find(userData.Id);

        if (user is null)
            return NotFound("n existe");

        await forumRepo.RoleUserPromoter(forum, user, role);

        return Ok();
    }



}
