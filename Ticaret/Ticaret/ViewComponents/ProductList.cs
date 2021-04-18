using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Service;

namespace Ticaret.ViewComponents
{
    public class ProductList: ViewComponent
    {
        private readonly IProductService _productService;

        public ProductList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _productService.GetAllProductAsync();  
            return View(result);
        }
    }
}
