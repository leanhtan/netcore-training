using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBlogEngine.Models;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;

namespace SimpleBlogEngine.Pages.Post
{
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
                    Content = a.Content
                };
                Category category = await categoryService.Get(a.CategoryId);
                post.CategoryName = category.Name;
                Posts.Add(post);
            });
        }
    }
}