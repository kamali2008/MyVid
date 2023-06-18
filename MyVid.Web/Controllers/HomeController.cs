using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVid.Core;
using MyVid.Core.Models;
using MyVid.Web.Models;
using System.Diagnostics;

namespace MyVid.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "admin,Super-Admin")]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /***** End poins de pruebas *****/

        [HttpPost]
        public async Task<IActionResult> AddPelicula([FromBody] Pelicula pelicula)
        {
            await _unitOfWork.PeliculaRepository.AddAsync(pelicula);
            await _unitOfWork.SaveChangesAsync();
            return new JsonResult(pelicula);
        }

        [HttpGet]
        public async Task<IActionResult> GetPelicula(int ID)
        {
           Pelicula? pelicula = await _unitOfWork.PeliculaRepository.GetByIdAsync(ID);
           // await _unitOfWork.SaveChangesAsync();
            return new JsonResult(pelicula);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePelicula(int ID)
        {
            Pelicula? pelicula = await _unitOfWork.PeliculaRepository.GetByIdAsync(ID);
            if (pelicula != null)
            {
                _unitOfWork.ContenidoRepository.Remove(pelicula.Contenido);
                await _unitOfWork.SaveChangesAsync();
                return Ok(pelicula);
            }
            else
            {
                return NotFound();
            }

        }
    }
}