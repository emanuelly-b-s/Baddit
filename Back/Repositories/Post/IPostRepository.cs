using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using DTO;

namespace Back.Repositories.PostRep;
public interface IPostRepository: IRepository<Post>
{
    Task Add(Post obj);
    Task<List<Post>> GetAllPostForum(int idForum);
    Task<IEnumerable<Post>> GetPostsForUser(int idUser);
    Task<List<Post>> GetPostsFeed();

}
