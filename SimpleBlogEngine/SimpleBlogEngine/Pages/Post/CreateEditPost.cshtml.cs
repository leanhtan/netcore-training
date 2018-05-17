using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleBlogEngine.Models;
using SimpleBlogEngine.Service.Interfaces;

namespace SimpleBlogEngine.Pages.Post
{
    public class CreateEditPostModel : PageModel
    {
        IPostService postService;
        ICategoryService categoryService;
        [BindProperty]
        public CreateEditPostViewModel createEditPostViewModel { get; set; } = new CreateEditPostViewModel();

        public CreateEditPostModel(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        public void OnGet(long? id)
        {
            createEditPostViewModel.Categories = categoryService.GetAll().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            if (id.HasValue)
            {
                Repository.Models.Post post = postService.Get(id.Value);
                if (post != null)
                {
                    createEditPostViewModel.Id = post.Id;
                    createEditPostViewModel.Title = post.Title;
                    createEditPostViewModel.Content = post.Content;
                    createEditPostViewModel.CategoryId = post.CategoryId;
                }
            }
        }

        public IActionResult OnPost(long? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Repository.Models.Post post = isNew ? new Repository.Models.Post
                    {
                        AddedDate = DateTime.UtcNow
                    } : postService.Get(id.Value);

                    post.Title = createEditPostViewModel.Title;
                    post.Content = createEditPostViewModel.Content;
                    post.CategoryId = createEditPostViewModel.CategoryId;
                    post.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    post.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        postService.Insert(post);
                    }
                    else
                    {
                        postService.Update(post);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToPage("Index");
        }
    }
}