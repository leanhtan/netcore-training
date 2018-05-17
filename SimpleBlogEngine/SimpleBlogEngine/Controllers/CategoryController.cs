using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogEngine.Models;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Index()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            categoryService.GetAll().ToList().ForEach(a =>
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
        public PartialViewResult AddEditCategory(long? id)
        {
            CategoryViewModel model = new CategoryViewModel();
            if (id.HasValue)
            {
                Category category = categoryService.Get(id.Value);
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
        public IActionResult AddEditCategory(long? id, CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Category category = isNew ? new Category
                    {
                        AddedDate = DateTime.UtcNow
                    }: categoryService.Get(id.Value);

                    category.Name = model.Name;
                    category.Description = model.Description;
                    category.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    category.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        categoryService.Insert(category);
                    }
                    else
                    {
                        categoryService.Update(category);
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
        public PartialViewResult DeleteCategory(long id)
        {
            Category category = categoryService.Get(id);
            return PartialView("_DeleteCategory", category?.Name);
        }

        [HttpPost]
        public IActionResult DeleteCategory(long id, IFormCollection form)
        {
            Category category = categoryService.Get(id);
            if (category != null)
            {
                categoryService.Delete(category);
            }
            return RedirectToAction("Index");
        }
    }
}
