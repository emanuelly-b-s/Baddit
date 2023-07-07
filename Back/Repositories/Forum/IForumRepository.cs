using Back.Model;
using DTO;

namespace Back.Repositories.ForumRep;

public interface IForumRepository : IRepository<Forum>
{
    Task<bool> ExistingForum(string forumName);
    Task<Forum> GetForumById(int id);
    Task<List<Forum>> GetParticipants(int id);
    Task AddUser(ListParticipantsForum participant);
    Task RemoveUser(ListParticipantsForum participant);
    Task<bool> ExistingUserOnForum(int userID, int forumId);
    Task<IEnumerable<Forum>> GetAllForums();


}
