using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TImeManagement.Services.Interfaces;
using TImeManagement.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Azure;

namespace TImeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

         
        [HttpGet]
        public IActionResult Register()
        {
            var roles = _accountService.GetRoles();
            ViewBag.RolesList = new SelectList(roles, "Id", "Name");

            return PartialView("_Register");
        }


        [Authorize(Policy = "AdminOnly")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);
                if (response.StatusCode == TImeManagement.Data.Enums.StatusCode.OK) 
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                    TempData["Success"] = "Регистрация нового пользователя успешна. Вход...";
                    return RedirectToAction("Start", "Home");
                }
                TempData["error"] = response.Description.ToString();
            }
            TempData["error"] = "Введенные данные не прошли валидацию";
            return RedirectToAction("Start", "Home");
        }



        [HttpGet]
        public IActionResult Login() 
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Start", "Home");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);
                if (response.StatusCode == TImeManagement.Data.Enums.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                    TempData["Success"] = "Вы успешно авторизировались";
                    return RedirectToAction("Start", "Home");
                }
                TempData["error"] = response.Description.ToString();
            }
            TempData["error"] = "Введенные данные не прошли валидацию";
            return View(model);
        }

        [HttpGet]
        public  IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                    var response = await _accountService.ChangePassword(model);
                    if (response.StatusCode == TImeManagement.Data.Enums.StatusCode.OK)
                    {
                        TempData["Success"] = "Вы успешно изменили пароль";
                        return RedirectToAction("Start", "Home");
                    }
                    TempData["error"] = response.Description.ToString();
            }
            TempData["error"] = "Пароль не изменен";
            return RedirectToAction("Start", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
