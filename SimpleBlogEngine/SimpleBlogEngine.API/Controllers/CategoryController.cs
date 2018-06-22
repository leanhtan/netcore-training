using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;

namespace SimpleBlogEngine.API.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        //[HttpPost("[action]")]
        //public async Task GetAll([FromBody] Category category)
        //{
        //    return await categoryService.
        //}
    }
}