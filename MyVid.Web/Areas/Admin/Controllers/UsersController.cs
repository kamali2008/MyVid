using Microsoft.AspNetCore.Mvc;
using MyVid.Core.Models;
using MyVid.Core.Services;
using MyVid.Core.Services.Users;

namespace MyVid.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserAuthenticationService _authService;

        public UsersController(IUserAuthenticationService authService) 
        {
            _authService = authService;
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            Usuario? usuario = await _authService.GetByEmailAsync(User.Identity.Name);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(Usuario model)
        {
            if (ModelState.IsValid)
            {
                Usuario? usuario = await _authService.GetByEmailAsync(model.Email);
             
                usuario.Nombre = model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.Genero = model.Genero;
                usuario.FechaNacemiento = model.FechaNacemiento;

                Status status = await _authService.UpdateUser(usuario);
                if (status.StatusCode == 1)
                {
                    return RedirectToAction("Profile");
                }
            }
            
            return View(model);
        }
    }
}
