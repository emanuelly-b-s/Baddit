using Microsoft.AspNetCore.Mvc;
using Security.Jwt;


namespace Baddit.Controllers;

using DTO;
using Back.Model;
using Microsoft.AspNetCore.Cors;
using Back.Repositories.User;
using SecurityService;
using UserServices;

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

    [HttpPost("new-account")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult> Register(
        [FromServices] IUserRepository<UserBaddit> userRep,
        [FromBody] NewUserDTO userData,
        [FromServices] ISecurityServiceJwt passJwt
    )
    {


        if (await userRep.ExistingNickName(userData.NickUser) || await userRep.ExistingEmail(userData.Email))
            return BadRequest("User ja existe");

        var passUserSalt = passJwt.ApplySalt();
        var passUserHash = passJwt.ApplyHash(userData.PasswordUser, passUserSalt);
        var passUserHash64 = Convert.ToBase64String(passUserHash);


        UserBaddit u = new()
        {

            Email = userData.Email,
            UserName = userData.UserName,
            LastName = userData.LastName,
            DateBirth = userData.DateBirth,
            NickUser = userData.NickUser,
            PasswordUser = passUserHash64,
            SaltPassword = passUserSalt,
            UserPhoto = userData.PhotoUser,
        };

        await userRep.Add(u);

        return Ok();

    }

    [HttpPost("login")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<LoginResultDTO>> Login([FromBody] LoginUserDTO loginData,
                                          [FromServices] IUserRepository<UserBaddit> userRep,
                                          [FromServices] ISecurityServiceJwt jwt,
                                          [FromServices] IJwtService jwtService

    )
    {
        var result = new LoginResultDTO();

        var userList = await userRep.Filter(u => u.Email == loginData.Email);

        result.User = userList.Count > 0;
        if (!result.User)
            return BadRequest("email incorreto");

        UserBaddit userLogin = userList.First();

        var hashUserDB = userLogin.PasswordUser;
        var saltUserDB = userLogin.SaltPassword;

        var passUserHash = jwt.PasswordIsCorrect(loginData.PasswordUser,
                                                 hashUserDB,
                                                 saltUserDB);

        if (jwt.PasswordIsCorrect(loginData.PasswordUser,
                                                 hashUserDB,
                                                 saltUserDB))
        {
            string token = jwtService.GetToken(new UserSecurityToken { IDUser = userLogin.Id, Authenticated = true });

            result.Jwt = token;
            result.SucessOnSession = true;
            return Ok(result);
        }

        if (!passUserHash)
            return BadRequest("senha incorreto");

        result.SucessOnSession = false;
        return Ok(userLogin);

    }

    [HttpPost("tokenValidate")]
    [EnableCors("MainPolicy")]
    public Task<ActionResult<UserSecurityToken>> ValidateJwt(
        [FromServices] IJwtService jwtService,
        [FromBody] JwtDTO jwt
    )
    {
        if (jwt.ValueToken == "" || jwt.ValueToken is null)
        {
            return Task.FromResult<ActionResult<UserSecurityToken>>(Ok(new UserSecurityToken { Authenticated = false }));
        }

        try
        {
            var result = jwtService.Validate<UserSecurityToken>(jwt.ValueToken);
            return Task.FromResult<ActionResult<UserSecurityToken>>(Ok(result));
        }
        catch (Exception)
        {
            return Task.FromResult<ActionResult<UserSecurityToken>>(Ok(new UserSecurityToken { Authenticated = false }));
        }
    }


    [HttpPost("userLoggedIn")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<UserBaddit>> Get(
        [FromServices] IUserService userService,
        [FromBody] JwtDTO jwt
    )
    {
        UserBaddit user;
        try
        {
            user = await userService.UserAuthenticationToken(jwt);
        }
        catch (Exception)
        {
            return BadRequest();
        }

        if (user is null)
            return BadRequest("n deu");


        InfoUser result = new()
        {
            UserId = user.Id,
            Username = user.UserName,
            NickUser = user.NickUser,
            Email = user.Email,
            PhotoUser = user.UserPhoto,
        };

        return Ok(result);
    }


    [HttpPost("getForumsRegister")]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<IEnumerable<Forum>>> GetForumsRegister(
        [FromServices] IUserRepository<UserBaddit> userRep,
        [FromBody] InfoUser user
    )
    {
        var groups = await userRep.GetGroups(user.UserId);

        return Ok(groups);
    }

}