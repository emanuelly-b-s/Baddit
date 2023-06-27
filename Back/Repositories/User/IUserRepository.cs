using Back.Model;

namespace Back.Repositories.User;

public interface IUserRepository : IRepository<UserBaddit>
{
    Task<bool> ExistingNickName(string userNickName);
    Task<bool> ExistingEmail(string userEmail);

}
