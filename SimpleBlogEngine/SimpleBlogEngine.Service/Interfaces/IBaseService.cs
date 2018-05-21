using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Service.Interfaces
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
