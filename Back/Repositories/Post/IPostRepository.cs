using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using DTO;

namespace Back.Repositories.PostRep;
public interface IPostRepository<T>
{
    Task AddPost(T obj);
    Task<List<Post>> GetAllPost(int idForum);
    Task UpdateUpDown(InfoPostDTO post);

}
