using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;

namespace SimpleBlogEngine.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
