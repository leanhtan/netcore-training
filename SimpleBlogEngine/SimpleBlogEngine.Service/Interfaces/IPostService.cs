﻿using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Services.Interfaces
{
    public interface IPostService : IBaseService<Post>
    {
        Task<IEnumerable<Post>> GetTop();

        Task<IEnumerable<Post>> GetByCategory(long id);

        Task<IEnumerable<Post>> Search(string searchContent);
    }
}
