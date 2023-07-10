using Back.Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using SecurityService;

namespace Back.Repositories.User;

public interface IUserRepository: IRepository<UserBaddit>
{
    Task<bool> ExistingNickName(string userNickName);
    Task<bool> ExistingEmail(string userEmail);
    Task<UserBaddit> GetUserByID(int id);
    Task<InfoUser> GetUserByName(string userName);
    Task<UserBaddit> Find(int id);
    Task<IEnumerable<Forum>> GetGroups (int id);
}
