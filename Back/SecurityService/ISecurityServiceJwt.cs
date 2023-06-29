using System;
namespace SecurityService;
public interface ISecurityServiceJwt
{
        byte[] ApplyHash(string pass);
        string ApplySalt();
        bool PasswordIsCorrect(string pass, byte[] passHashedFromBd, string salt);
}
