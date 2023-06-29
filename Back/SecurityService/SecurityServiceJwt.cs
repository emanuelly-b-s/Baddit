using System;
using System.Text;
using System.Security.Cryptography;

namespace SecurityService;

public class SecurityServiceJwt : ISecurityServiceJwt
{


    public string ApplySalt()
    {
        Random rand = new();
        int length = 12;

        byte[] salt = new byte[length];
        rand.NextBytes(salt);

        var saltTo64 = Convert.ToBase64String(salt);

        return saltTo64;
    }
    public byte[] Hash(string pass, string salt)
    {

        var passSalt = pass + salt;
        var bytePasswordSalt = Encoding.UTF8.GetBytes(passSalt);
        var byteHash = SHA256.HashData(bytePasswordSalt);

        return byteHash;
    }
    public bool PasswordIsCorrect(string pass, byte[] passHashDTB, string salt)
    {
        var passwordHashed = Hash(pass, salt);

        for (int i = 0; i < passHashDTB.Length; i++)
        {
            if (passwordHashed[i] != passHashDTB[i])
                return false;
        }
        return true;
    }
    public byte[] ApplyHash(string pass)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(pass);
        var hashBytes = SHA256.HashData(passwordBytes);
        return hashBytes;
    }


}

