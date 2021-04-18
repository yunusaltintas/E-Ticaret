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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {

            var result = await _productService.GetProductWithCategory();

            return View(result);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addProductViewModel);
            }

            _productService.AddProduct(addProductViewModel);

            return RedirectToAction("Index","Product",new { area="Admin" } );
        }

    }
}
