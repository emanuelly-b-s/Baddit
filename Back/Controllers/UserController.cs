using Microsoft.AspNetCore.Mvc;

namespace Baddit.Controllers;

using DTO;
using Back.Model;
using Microsoft.AspNetCore.Cors;
using Back.Repositories.User;
using SecurityService;

[ApiController]
[Route("user")]
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
    public async Task<ActionResult> Register([FromServices] IUserRepository<UserBaddit> userRep,
                                             [FromBody] NewUserDTO userData,
                                             [FromServices] ISecurityServiceJwt passJwt
    )
    {

        string salt = passJwt.ApplySalt();
        byte[] hashPass = passJwt.ApplyHash(userData.PasswordUser, salt);

        if (await userRep.ExistingNickName(userData.NickUser) || await userRep.ExistingEmail(userData.Email))
            return BadRequest("User ja existe");


        UserBaddit u = new()
        {

            Email = userData.Email,
            UserName = userData.UserName,
            LastName = userData.LastName,
            DateBirth = userData.DateBirth,
            NickUser = userData.NickUser,
            PasswordUser = hashPass.ToString(),
            SaldPassword = salt,
            PhotoUser = userData.PhotoUser,
        };

        await userRep.Add(u);

        return Ok();

    }

    [HttpPost("{login}")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Login([FromBody] LoginUserDTO loginData,
                                          [FromServices] IUserRepository<UserBaddit> userRep)
    {

        string pass = loginData.PasswordUser;
        string email = loginData.Email;

        var userList = await userRep.Filter(u => u.Email.Equals(email)
                                                 && u.PasswordUser.Equals(pass));

        if (userList.Count == 0)
            return BadRequest("email ou senha incorreto");

        UserBaddit userLogin = userList.First();

        return Ok(userLogin);

    }
}