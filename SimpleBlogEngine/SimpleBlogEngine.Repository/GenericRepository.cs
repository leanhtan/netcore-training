using Microsoft.EntityFrameworkCore;
using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogEngine.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        private DbSet<T> entities;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }


        public void Delete(T entity)
        {            
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}
