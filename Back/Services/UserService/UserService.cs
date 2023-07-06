using Back.Model;
using Back.Repositories.User;
using DTO;
using Security.Jwt;

namespace UserServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public UserService(IJwtService jwtService, IUserRepository userRepository)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<UserBaddit> UserAuthenticationToken(JwtDTO jwt)
    {
        UserBaddit user;

        var token = _jwtService.Validate<UserSecurityToken>(jwt.ValueToken);

        if(!token.Authenticated)
            throw new Exception("errou");

        return await _userRepository.GetUserByID(token.IDUser);
    }
}