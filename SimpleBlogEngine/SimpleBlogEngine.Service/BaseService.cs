using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> genericRepository;

        public BaseService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<T> Get(long id)
        {
            return await genericRepository.Get(id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await genericRepository.Insert(entity);
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await genericRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var entity = await genericRepository.Get(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await genericRepository.Delete(entity);
        }
    }
}
