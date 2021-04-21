using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ViewModels;
using Ticaret.Service;

namespace Ticaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {

            var result = await _productService.GetProductWithCategory();

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> AddProductAsync()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            var categories = result.Model;

            ViewBag.categories = new SelectList(categories, "Id", "CategoryName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductViewModel addProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                var result = await _categoryService.GetAllCategoryAsync();
                var categories = result.Model;
                ViewBag.categories = new SelectList(categories, "Id", "CategoryName");

                return View(addProductViewModel);
            }

            await _productService.AddProduct(addProductViewModel);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            UpdateProductViewModel updateProductViewModel = new UpdateProductViewModel
            {
                ProductName = result.Model.ProductName,
                CategoryId = result.Model.CategoryId,
                Price = result.Model.Price,

            };

            return View(updateProductViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateProductViewModel);
            }

            var result = await _productService.UpdateProduct(updateProductViewModel);


            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }


    }
}
