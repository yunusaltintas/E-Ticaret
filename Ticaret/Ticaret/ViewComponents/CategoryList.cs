using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Service;

namespace Ticaret.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result=await _categoryService.GetAllCategoryOrderLetterAsync();
            return View(result);
        }
    }
}
