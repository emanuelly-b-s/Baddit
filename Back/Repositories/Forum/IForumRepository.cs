using Back.Model;
using DTO;

namespace Back.Repositories.ForumRep;

public interface IForumRepository : IRepository<Forum>
{
    Task<bool> ExistingForum(string forumName);
    Task<Forum> GetForumById(int id);
    Task<List<ParticipantForum>> GetGroupMembers(InfoForum forum);
    Task AddUser(ListParticipantsForum participant);
    Task RemoveUser(ListParticipantsForum participant);
    Task<bool> ExistingUserOnForum(int userID, int forumId);
    Task<IEnumerable<Forum>> GetAllForums();
    Task<bool> IsMember(int user, int forum);
    Task<List<Forum>> Search(string forum);
    Task<Forum> FindForum(int id);
    Task RoleUserPromoter(Forum forum, UserBaddit user, Role role);

}
