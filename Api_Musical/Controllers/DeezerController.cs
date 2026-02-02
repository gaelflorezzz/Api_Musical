using Api_Musical.Models;
using Api_Musical.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Musical.Controllers
{
    public class DeezerController : Controller
    {
        private readonly DeezerService _deezerService;

        public DeezerController(DeezerService deezerService)
        {
            _deezerService = deezerService;
        }

        public async Task<IActionResult> Index(string busqueda)
        {
            if (string.IsNullOrEmpty(busqueda))
                return View(new List<Cancion>());

            var cancion = await _deezerService.GetCancion(busqueda);
            return View(cancion);
        }
    }
}
