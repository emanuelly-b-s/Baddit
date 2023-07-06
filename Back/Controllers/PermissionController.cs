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
[Route("forum/role/permission")]
public class PermissionController : ControllerBase
{
    [HttpPost("new-permission")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Permission(
        [FromServices] IPermissionRepository roleRep,
        [FromBody] PermissionDTO permissionData
    )
    {

        Permission p = new()
        {
            PermissionName = permissionData.PermissionName
        };

        await roleRep.Add(p);

        return Ok();
    }

    [HttpGet("get-permissions")]
    [EnableCors("MainPolicy")]
    public async Task<List<Permission>> Permissions(
        [FromServices] IPermissionRepository permissionRep
    ) => await permissionRep.GetAllPermission();

}