using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogEngine.Service
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
