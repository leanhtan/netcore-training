using SimpleBlogEngine.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Services.Interfaces
{
    public interface ICommentService : IBaseService<Comment>
    {
        Task<IEnumerable<Comment>> GetByPost(long id);
    }
}
