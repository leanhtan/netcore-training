using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;

namespace SimpleBlogEngine.Services
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
