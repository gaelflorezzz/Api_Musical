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
            List<Cancion> canciones;

            if (!string.IsNullOrEmpty(busqueda))
            {
                canciones = await _deezerService.GetCancion(busqueda);    
            }
            else
            {
                canciones = await _deezerService.GetTopMexico();
            }

            return View(canciones);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerArtista(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return RedirectToAction("Index");

            var listaArtistas = await _deezerService.GetArtista(nombre);

            return View("Artistas", listaArtistas);
        }
    }
}
