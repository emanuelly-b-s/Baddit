using Back.Model;

namespace Back.Repositories.ForumRep;

public interface IForumRepository<Forum> : IRepository<Forum>
{
    Task<bool> ExistingForum(string forumName);
    Task<Forum> GetForumById(int id);

}
