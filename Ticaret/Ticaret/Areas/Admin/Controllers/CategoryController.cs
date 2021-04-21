using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Data.ViewModels;
using Ticaret.Service;

namespace Ticaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var result = await _categoryService.GetAllCategoryOrderLetterAsync();

            return View(result);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            //throw new Exception("error var");
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addCategoryViewModel);
            }
            _categoryService.AddCategory(addCategoryViewModel);

            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
           var result= await _categoryService.GetCategoryByIdAsync(id);
            UpdateCategoryViewModel updateCategoryViewModel = new UpdateCategoryViewModel
            {
                CategoryName = result.Model.CategoryName
            };
            return View(updateCategoryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateCategoryViewModel);
            }
           var result=await _categoryService.UpdateCategory(updateCategoryViewModel);
            return RedirectToAction("Index", "Category", new { area="Admin"});
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result=await _categoryService.DeleteCategoryAsync(id);
           
            return RedirectToAction("Index");
        }

    }
}
