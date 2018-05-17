using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBlogEngine.Service.Interfaces;

namespace SimpleBlogEngine.Pages.Post
{
    public class DeletePostModel : PageModel
    {
        IPostService postService;
        [BindProperty]
        public Repository.Models.Post post { get; set; }

        public DeletePostModel(IPostService postService)
        {
            this.postService = postService;
        }

        public void OnGet(long id)
        {
            post = postService.Get(id);
        }

        public IActionResult OnPost(long id)
        {
            if (post != null)
            {
                postService.Delete(post);
            }
            return RedirectToPage("Index");
        }
    }
}