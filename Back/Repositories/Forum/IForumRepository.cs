using Back.Model;
using DTO;

namespace Back.Repositories.ForumRep;

public interface IForumRepository : IRepository<Forum>
{
    Task<bool> ExistingForum(string forumName);
    Task<Forum> GetForumById(int id);
    Task<IEnumerable<InfoUser>> GetParticipants(int id);
    Task AddUser(ListParticipantsForum participant);
    Task RemoveUser(ListParticipantsForum participant);
    Task<bool> ExistingUserOnForum(int userID, int forumId);
    Task<IEnumerable<Forum>> GetAllForums();
    Task<bool> IsMember(int user, int forum);
    Task<List<Forum>> Search(string forum);

}
