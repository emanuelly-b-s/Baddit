using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Model;
using DTO;

namespace Back.Repositories;

public interface IUpDownRepository : IRepository<UpvoteDownvote>
{
    Task Add(UpvoteDownvote obj);
    int CountUpvote();
}
