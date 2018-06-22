using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T> Get(long id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(long id);
    }
}
