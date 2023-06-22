using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Back.Model;

[ApiController]
[Route("login")]
[EnableCors("MainPolicy")]
public class UserController : Controller
{
    [HttpPost("{login}")]

    public async Task<ActionResult<string>> Post(
        [FromBody] IRepository<UserBaddit> repo
    )
    {

    }
}