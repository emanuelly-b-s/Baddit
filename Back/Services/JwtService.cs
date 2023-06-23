using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Back.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace JwtService;
public class JwtService<T> : IJwtService<T>
{

    private readonly UserBaddit _user;

    public JwtService(UserBaddit user)
        => _user = user;

    public bool ValidateUser(UserBaddit user)
    {
        bool isValid = true;
        bool invalid = false;

        if (user == null)
            return invalid;

        return isValid;

    }

    public async Task<string> GenerateTokenAsync(UserBaddit user, string role)
    {
        ValidateUser(user);

        var claims = GetTokenClaims(user, role);
        var token = await GenerateJwtTokenAsync(claims);

        return token;
    }

    public async Task<bool> ValidateTokenAsync(string token, UserBaddit user)
    {
        try
        {
            var validatedToken = await ValidateJwtTokenAsync(token);
            user = GetUserFromClaims(validatedToken.Claims);

            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

    IEnumerable<Claim> GetTokenClaims(UserBaddit user, string role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        if (!string.IsNullOrEmpty(role))
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }

    async Task<string> GenerateJwtTokenAsync(IEnumerable<Claim> claims)
    {
       var key = Encoding.UTF8.GetBytes("chave_secreta_do_token_jwt");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return await Task.FromResult(tokenHandler.WriteToken(token));
    }

    async Task<JwtSecurityToken> ValidateJwtTokenAsync(string token)
    {
         var key = Encoding.UTF8.GetBytes("chave_secreta_do_token_jwt");

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var validatedToken = await Task.FromResult(tokenHandler.ValidateToken(token, validationParameters, out var securityToken));

        if (securityToken is not JwtSecurityToken jwtSecurityToken)
            throw new SecurityTokenException("Token inválido");


        return jwtSecurityToken;
    }

    UserBaddit GetUserFromClaims(IEnumerable<Claim> claims)
    {
         var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            return _user;

        throw new SecurityTokenException("Usuário inválido no token");
    }

}