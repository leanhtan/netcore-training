using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SimpleBlogEngine.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        readonly IGenericRepository<Post> postRepository;

        public PostService(IGenericRepository<Post> postRepository) : base(postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetTop()
        {
            var posts = await postRepository.GetAll();
            return posts.OrderByDescending(x => x.AddedDate).Take(10);
        }

        public async Task<IEnumerable<Post>> GetByCategory(long id)
        {
            var posts = await postRepository.GetAll();
            return posts.Where(x => x.CategoryId == id);
        }
    }
}
