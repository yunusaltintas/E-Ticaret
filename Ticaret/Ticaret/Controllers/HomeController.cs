using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;
using Ticaret.Data.ViewModels;
using Ticaret.Service;

namespace Ticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(
            IProductService productService,
            ICategoryService categoryService,
            SignInManager<AppUser> signInManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetProductDetailAsync(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginModel);
            }
            var SignInResult = _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, userLoginModel.RememberMe, false).Result;
            if (!SignInResult.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı veya Şifre hatalı");
                return View();
            }

            return RedirectToAction("Index", "Product", new { area = "Admin" });
         
        }



    }
}
