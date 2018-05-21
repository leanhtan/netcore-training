using Microsoft.EntityFrameworkCore;
using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task Delete(T entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> Get(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            await context.SaveChangesAsync();
        }
    }
}
