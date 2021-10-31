using InterviewProject.Bll;
using InterviewProject.MVCWebUI.Identity;
using InterviewProject.MVCWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =  await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı bulunamadı!");
                }
                var result = await _signInManager.PasswordSignInAsync(user, EncryptPassword.encrypt(model.Password), false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("CreateExam", "Home");
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                return View(model);
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.Username,
                    PasswordHash = EncryptPassword.encrypt(model.Password)
                };

                var result = await _userManager.CreateAsync(user, EncryptPassword.encrypt(model.Password));
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
