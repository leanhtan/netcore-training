using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T> Get(long id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
