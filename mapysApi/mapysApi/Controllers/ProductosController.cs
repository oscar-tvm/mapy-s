using mapysApi.Data.Repositories;
using mapysApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using Newtonsoft.Json;

namespace mapysApi.Controllers
{
    [Route("api/mapys/productos")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductosController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        [HttpGet]
        [Route("/api/mapys/productos/tipo/{tipoProducto}")]
        public async Task<IActionResult> GetAllProductos(string tipoProducto)
        {
            // Obtener los datos de productos desde el repositorio
            var productos = await _productoRepositorio.GetAllProductos(tipoProducto);

            // Crear un objeto anónimo con la propiedad "data"
            var respuesta = new { data = productos };

            // Serializar el objeto anónimo a JSON
            var json = JsonConvert.SerializeObject(respuesta);

            // Retornar la respuesta JSON
            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetProductoGetProducto(int codigo)
        {
            // Obtener el producto desde el repositorio
            var producto = await _productoRepositorio.GetProductoById(codigo);

            // Serializar el producto a JSON
            var json = JsonConvert.SerializeObject(producto);

            // Retornar la respuesta JSON 
            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        [HttpGet]
        [Route("/api/mapys/productos/descuento")]
        public async Task<IActionResult> GetProductosDescuento()
        {
            // Obtener productos con descuento.
            var producto = await _productoRepositorio.GetProductosDescuento();

            // Serializar el producto a JSON
            var json = JsonConvert.SerializeObject(producto);

            // Retornar la respuesta JSON
            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest("La solicitud es incorrecta o mal formada.");

            // ModelState.IsValid es una propiedad booleana que devuelve true
            // si el modelo de datos no tiene errores de validación y cumple con las
            // reglas de validación definidas en el modelo, y devuelve false en caso contrario.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created  = await _productoRepositorio.InsertProducto(producto);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest("La solicitud es incorrecta o mal formada.");

            // ModelState.IsValid es una propiedad booleana que devuelve true
            // si el modelo de datos no tiene errores de validación y cumple con las
            // reglas de validación definidas en el modelo, y devuelve false en caso contrario.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productoRepositorio.Update(producto);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducto(int codigo)
        {
            await _productoRepositorio.DeleteProducto(new Producto { Codigo = codigo });
            return NoContent();
        }
    }
}
