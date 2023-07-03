using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repositories.PostRep;
public interface IPostRepository<Post> 
{
    Task AddPost(Post post);
}
