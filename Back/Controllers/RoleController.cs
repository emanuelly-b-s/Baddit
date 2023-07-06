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

        await roleRep.Add(r);

        return Ok();
    }

    
    [HttpPost("new-permission")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Permission(
        [FromServices] IRoleRepository roleRep,
        [FromBody] PermissionDTO permissionData
    )
    {

        Permission p = new()
        {
            PermissionName = permissionData.PermissionName
        };

        await roleRep.AddPermission(p);

        return Ok();
    }


}
