using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogEngine.Service.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
