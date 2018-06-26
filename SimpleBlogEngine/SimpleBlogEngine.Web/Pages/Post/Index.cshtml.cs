using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;
using SimpleBlogEngine.Web.Models.PostViewModels;

namespace SimpleBlogEngine.Web.Pages.Post
{
    [Authorize]
    public class IndexModel : PageModel
    {
        IPostService postService;
        ICategoryService categoryService;
        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();

        public IndexModel(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        public async Task OnGet()
        {
            var postCollection = await postService.GetAll();
            postCollection.ToList().ForEach(async a =>
            {
                PostViewModel post = new PostViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = string.Format("{0}...", a.Content.Length > 200 ? a.Content.Substring(0, 200) : a.Content)
                };
                Category category = await categoryService.Get(a.CategoryId);
                post.CategoryName = category.Name;
                Posts.Add(post);
            });
        }
    }
}