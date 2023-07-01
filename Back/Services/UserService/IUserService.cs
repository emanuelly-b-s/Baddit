using Back.Model;
using DTO;
using Security.Jwt;

namespace UserServices;

public interface IUserService
{
    Task<UserBaddit> UserAuthenticationToken(JwtDTO jwt);
}