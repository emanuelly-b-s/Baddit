using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace Back.Repositories;

public interface IUpDownRepository<T> : IRepository<T>
{
    Task Add(T obj);
    int CountUpvote(InfoPostDTO post);
}
