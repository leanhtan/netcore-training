using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogEngine.Models;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
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
                    }: await categoryService.Get(id.Value);

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
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<PartialViewResult> DeleteCategory(long id)
        {
            Category category = await categoryService.Get(id);
            return PartialView("_DeleteCategory", category?.Name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(long id, IFormCollection form)
        {
            await categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
