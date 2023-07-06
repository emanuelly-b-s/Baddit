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
    Task<List<Post>> GetAllPost(int idForum);
    Task<List<Post>> GetPostsFeed(int idUser);

}
