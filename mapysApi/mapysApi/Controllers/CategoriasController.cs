using mapysApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace mapysApi.Controllers
{
    [Route("api/mapys/categorias")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            var categorias = await _categoriaRepositorio.GetAllCategorias();

            // Crear un objeto anónimo con la propiedad "data"
            var respuesta = new { data = categorias };

            // Retornar un JsonResult con el objeto anónimo como contenido
            return new JsonResult(respuesta);
        }
    }
}
