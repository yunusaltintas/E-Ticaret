using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
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
        private readonly UserManager<AppUser> _userManager;

        public HomeController(
            IProductService productService,
            ICategoryService categoryService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
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
        [HttpGet]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
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
        [HttpGet]
        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;

            return View();
        }
        [Route("/Error")]
        [HttpGet]
        public IActionResult Error()
        {
            var ErrorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(NLog.LogLevel.Error, $"\nHatanın Gerçekleştiği yer:{ErrorInfo.Path}\nHata Mesajı: {ErrorInfo.Error.Message}\nStack Trace:{ErrorInfo.Error.StackTrace}");
            return View();
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPasswordAsync(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgetPasswordViewModel);
            }

            AppUser User = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Email);
            if (User != null)
            {
                string ResetToken = await _userManager.GeneratePasswordResetTokenAsync(User);

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(User.Email);
                mail.From = new MailAddress("denemeyeagmail.com", "Şifre Güncelleme", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:5001{Url.Action("UpdatePassword", "Home", new { userId = User.Id, token = HttpUtility.UrlEncode(ResetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;
                SmtpClient smp = new SmtpClient();
                smp.Credentials = new NetworkCredential("denemeyea@gmail.com@gmail.com", "yea123456");
                smp.Port = 587;
                smp.Host = "smtp.gmail.com";
                smp.EnableSsl = true;
                smp.Send(mail);
                ViewBag.State = false;
            }
            else
            {
                ViewBag.State = false;
            }

            return RedirectToAction("Login", "Home");
        }




    }
}
