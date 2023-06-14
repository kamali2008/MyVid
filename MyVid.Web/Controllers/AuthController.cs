using Microsoft.AspNetCore.Mvc;
using MyVid.Web.Models.Auth;

namespace MyVid.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(LoginViewModel model)
        {
           return RedirectToAction("Index", "Home");
        }
    }
}
