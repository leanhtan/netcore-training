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

        public async Task OnGet(long id)
        {
            post = await postService.Get(id);
        }

        public async Task<IActionResult> OnPost(long id)
        {
            await postService.Delete(post.Id);
            return RedirectToPage("Index");
        }
    }
}