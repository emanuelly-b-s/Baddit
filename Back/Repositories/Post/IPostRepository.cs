using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repositories.PostRep;
public interface IPostRepository<T> 
{
    Task AddPost(T obj);
}
