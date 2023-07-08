// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Back.Model;
// using Back.Repositories;
// using DTO;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.AspNetCore.Mvc;

// namespace Back.Controllers;

// [ApiController]
// [Route("forum/permissionController")]
// public class RolePermissionController : ControllerBase
// { 
//     [HttpPost("new-permissionRole")]
//     [EnableCors("MainPolicy")]
//     public async Task<ActionResult> Reister(
//         [FromServices] PermissionRoleRepository rolePerRep,
//         [FromBody] PermissionRoleDTO permissionData
//     )
//     {

//         RolePermission p = new()
//         {
//             RoleId = permissionData.IdRole,
//             PermissionId = permissionData.IdPermission
//         };

//         await rolePerRep.Add(p);

//         return Ok();
//     }
// }