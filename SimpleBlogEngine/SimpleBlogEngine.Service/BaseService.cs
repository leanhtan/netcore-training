using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogEngine.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> genericRepository;

        public BaseService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public IEnumerable<T> GetAll()
        {
            return genericRepository.GetAll();
        }

        public T Get(long id)
        {
            return genericRepository.Get(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            genericRepository.Insert(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            genericRepository.Update(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            genericRepository.Delete(entity);
        }
    }
}
