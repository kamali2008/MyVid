using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MyVid.Core.Models;
using MyVid.Core.Services.Users;
using MyVid.Web.Models.Auth;

namespace MyVid.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserAuthenticationService _authService;

        public AuthController(IUserAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model.Email, model.Password);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
               
                return View(model);
            }
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            string role = "Super-Admin";
            Usuario usuario = new Usuario { 
                Nombre = model.Nombre,
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var result = await this._authService.RegisterAsync(usuario, model.Password, role);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Login));

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
