using Back.Model;
using DTO;
using SecurityService;

namespace Back.Repositories.User;

public interface IUserRepository<UserBaddit> : IRepository<UserBaddit>
{
    Task<bool> ExistingNickName(string userNickName);
    Task<bool> ExistingEmail(string userEmail);
    Task<UserBaddit> GetUserByID(int id);
    Task<InfoUser> GetUserByName(string userName);
}
