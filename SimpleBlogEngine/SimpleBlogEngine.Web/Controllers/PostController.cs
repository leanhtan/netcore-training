using Microsoft.AspNetCore.Mvc;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;
using SimpleBlogEngine.Web.Models.PostViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        IPostService postService;
        ICategoryService categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<PostViewModel>> GetAll()
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            var postCollection = await postService.GetAll();
            postCollection.ToList().ForEach(async a =>
            {
                PostViewModel post = new PostViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content
                };
                Category category = await categoryService.Get(a.CategoryId);
                post.CategoryName = category.Name;
                posts.Add(post);
            });
            return posts;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var post = await postService.Get(id);
            return Ok(new PostViewModel
            {
                Title = post.Title,
                Content = post.Content,
            });
        }

        [HttpGet()]
        public async Task<List<PostViewModel>> GetTop()
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            var postCollection = await postService.GetTop();
            postCollection.ToList().ForEach(async a =>
            {
                PostViewModel post = new PostViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = string.Format("{0}...", a.Content.Length > 100 ? a.Content.Substring(0, 100) : a.Content)
                };
                Category category = await categoryService.Get(a.CategoryId);
                post.CategoryName = category.Name;
                posts.Add(post);
            });
            return posts;
        }

        [HttpGet("{id}")]
        public async Task<LazyPostViewModel> GetByCategory(long id, int getIndex, int amount)
        {
            var postCollection = await postService.GetByCategory(id);
            var lazyPosts = new LazyPostViewModel
            {
                Total = postCollection.Count()
            };
            postCollection.Skip(getIndex - 1).Take(amount).ToList().ForEach(async a =>
              {
                  PostViewModel post = new PostViewModel
                  {
                      Id = a.Id,
                      Title = a.Title,
                      Content = string.Format("{0}...", a.Content.Length > 100 ? a.Content.Substring(0, 100) : a.Content)
                  };
                  Category category = await categoryService.Get(a.CategoryId);
                  post.CategoryName = category.Name;
                  lazyPosts.Posts.Add(post);
              });
            return lazyPosts;
        }

        [HttpGet()]
        public async Task<LazyPostViewModel> Search(string searchContent, int getIndex, int amount)
        {
            var postCollection = await postService.Search(searchContent);
            var lazyPosts = new LazyPostViewModel
            {
                Total = postCollection.Count()
            };
            postCollection.Skip(getIndex - 1).Take(amount).ToList().ForEach(async a =>
            {
                PostViewModel post = new PostViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = string.Format("{0}...", a.Content.Length > 100 ? a.Content.Substring(0, 100) : a.Content)
                };
                Category category = await categoryService.Get(a.CategoryId);
                post.CategoryName = category.Name;
                lazyPosts.Posts.Add(post);
            });
            return lazyPosts;
        }
    }
}
