using Microsoft.AspNetCore.Mvc;

namespace Baddit.Controllers;

using DTO;
using Back.Model;
using Microsoft.AspNetCore.Cors;
using Back.Repositories.User;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{

    [HttpGet]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<List<UserBaddit>>> GetAll(
        [FromServices] IUserRepository<UserBaddit> userRepository
    )
    {
        var query = await userRepository.Filter(u => true);
        return query;
    }

    [HttpPost("/newaccountuser")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Register(
        [FromServices] IUserRepository<UserBaddit> userRep,
        [FromBody]  NewUserDTO userData)
    {
        if (await userRep.ExistingNickName(userData.NickUser) || await userRep.ExistingEmail(userData.Email))
            return BadRequest("User ja existe");


        UserBaddit u = new UserBaddit()
        {

            Email = userData.Email,
            UserName = userData.UserName,
            LastName = userData.LastName,
            DateBirth = userData.DateBirth,
            NickUser = userData.NickUser,
            PasswordUser = userData.PasswordUser,
            SaldPassword = "",
            // PhotoUser = null,
        };

        await userRep.Add(u);

        return Ok();

    }

    // [HttpPost("/login")]
    // [EnableCors("MainPolicy")]
    // public async Task<ActionResult> Login('                                      
    //     [FromBody] UserLogin loginData,
    //     [FromServices] IPasswordHasher psh,
    //     [FromServices] UserRepository userRep
    // )
    // {
    //     var userList = await userRep.Filter(u => u.Email == loginData.Email);

    //     if (userList.Count() == 0)
    //         return BadRequest();

    //     User target = userList.First();

    //     if (psh.Validate(loginData.Password, target.Salt, target.Password))
    //         return Ok();

    //     return BadRequest();
    // }
}