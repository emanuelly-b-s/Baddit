using Microsoft.AspNetCore.Mvc;
using 

using Back.Model;
using Microsoft.AspNetCore.Authorization;

namespace Back.Controllers;

[Authorize]
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    // [HttpPost("/")]

    // public async Task<ActionResult<UserBaddit>> NewUser(
    //     [FromServices] UserBaddit userRep,
    //     [FromServices] IPasswordHasher psh,
    //     [FromServices] ISaltProvider slp,
    //     [FromBody] UserRegister registerData)
    //     [FromBody] IRepository<UserBaddit> repo
    // )
    // {

    // }


}
