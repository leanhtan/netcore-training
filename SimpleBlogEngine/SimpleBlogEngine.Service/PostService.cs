using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;

namespace SimpleBlogEngine.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        readonly IGenericRepository<Post> postRepository;

        public PostService(IGenericRepository<Post> postRepository) : base(postRepository)
        {
            this.postRepository = postRepository;
        }
    }
}
