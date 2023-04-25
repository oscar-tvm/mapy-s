using FluentValidation;
using mapysApi.Data.Repositories;
using mapysApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace mapysApi.Controllers
{
    [Route("api/mapys/mensaje-cliente")]
    [ApiController]
    public class MensajeClienteController : Controller
    {
        private readonly IMensajeClienteRepositorio _mensajeClienteRepositorio;
        private readonly MensajeClienteValidator _validator;

        public MensajeClienteController(IMensajeClienteRepositorio mensajeClienteRepositorio)
        {
            _mensajeClienteRepositorio = mensajeClienteRepositorio;
            _validator = new MensajeClienteValidator();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMensajeCliente([FromBody] MensajeCliente mensajeCliente)
        {
            // Validar el modelo
            var validationResult = await _validator.ValidateAsync(mensajeCliente);
            if (!validationResult.IsValid)
            {
                // Organizar los mensajes de error en un diccionario
                var errors = new Dictionary<string, string[]>();
                foreach (var error in validationResult.Errors)
                {
                    if (!errors.ContainsKey(error.PropertyName))
                    {
                        errors[error.PropertyName] = new string[] { error.ErrorMessage };
                    }
                    else
                    {
                        errors[error.PropertyName] = errors[error.PropertyName].Concat(new string[] { error.ErrorMessage }).ToArray();
                    }
                }

                // Devolver la respuesta de error con los mensajes de error organizados
                return BadRequest(errors);
            }

            if (mensajeCliente == null)
                return BadRequest("La solicitud es incorrecta o mal formada.");

            // ModelState.IsValid es una propiedad booleana que devuelve true
            // si el modelo de datos no tiene errores de validación y cumple con las
            // reglas de validación definidas en el modelo, y devuelve false en caso contrario.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _mensajeClienteRepositorio.InsertMensajeCliente(mensajeCliente);

            return Created("created", created);
        }
    }
}
