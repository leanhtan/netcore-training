using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SimpleBlogEngine.Web.Models.CategoryViewModels;

namespace SimpleBlogEngine.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]    
    public class CategoryController : Controller
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Index()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            var categoryCollection = await categoryService.GetAll();
            categoryCollection.ToList().ForEach(a =>
            {
                CategoryViewModel category = new CategoryViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                };
                categories.Add(category);
            });
            return View("Index", categories);
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<PartialViewResult> AddEditCategory(long? id)
        {
            CategoryViewModel model = new CategoryViewModel();
            if (id.HasValue)
            {
                Category category = await categoryService.Get(id.Value);
                if (category != null)
                {
                    model.Id = category.Id;
                    model.Name = category.Name;
                    model.Description = category.Description;
                }
            }
            return PartialView("_AddEditCategory", model);
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> AddEditCategory(long? id, CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Category category = isNew ? new Category
                    {
                        AddedDate = DateTime.UtcNow
                    } : await categoryService.Get(id.Value);

                    category.Name = model.Name;
                    category.Description = model.Description;
                    category.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    category.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        await categoryService.Insert(category);
                    }
                    else
                    {
                        await categoryService.Update(category);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<PartialViewResult> DeleteCategory(long id)
        {
            Category category = await categoryService.Get(id);
            return PartialView("_DeleteCategory", category?.Name);
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> DeleteCategory(long id, IFormCollection form)
        {
            await categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<CategoryViewModel>> GetAll()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            var categoryCollection = await categoryService.GetAll();
            categoryCollection.ToList().ForEach(a =>
            {
                CategoryViewModel category = new CategoryViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                };
                categories.Add(category);
            });
            return categories;
        }
    }
}
