using Back.Model;
using SecurityService;

namespace Back.Repositories.User;

public interface IUserRepository<UserBaddit> : IRepository<UserBaddit>
{
    Task<bool> ExistingNickName(string userNickName);
    Task<bool> ExistingEmail(string userEmail);


}
