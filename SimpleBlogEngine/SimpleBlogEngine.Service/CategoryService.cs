using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;

namespace SimpleBlogEngine.Service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        readonly IGenericRepository<Category> categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository) : base(categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
    }
}
