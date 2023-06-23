using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Back.Model;

namespace JwtService;
public interface IJwtService<T>
{

    bool ValidateUser(UserBaddit user);
    public Task<string> GenerateTokenAsync(UserBaddit user, string role);
    public Task<bool> ValidateTokenAsync(string token, UserBaddit user);
    IEnumerable<Claim> GetTokenClaims(UserBaddit user, string role);
    Task<string> GenerateJwtTokenAsync(IEnumerable<Claim> claims);
     Task<JwtSecurityToken> ValidateJwtTokenAsync(string token);
    UserBaddit GetUserFromClaims(IEnumerable<Claim> claims);

}