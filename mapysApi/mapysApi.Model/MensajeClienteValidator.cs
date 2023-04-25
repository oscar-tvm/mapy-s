using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Model
{
    public class MensajeClienteValidator : AbstractValidator<MensajeCliente>
    {
        public MensajeClienteValidator()
        {
            RuleFor(m => m.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(50).WithMessage("El nombre debe tener como máximo 50 caracteres.");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("El email proporcionado no es válido.")
                .MaximumLength(50).WithMessage("El email debe tener como máximo 50 caracteres.");

            RuleFor(m => m.Ciudad)
                .NotEmpty().WithMessage("La ciudad es obligatoria.")
                .MaximumLength(30).WithMessage("La ciudad debe tener como máximo 30 caracteres.");

            RuleFor(m => m.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(20).WithMessage("El teléfono debe tener como máximo 20 caracteres.");

            RuleFor(m => m.Mensaje)
                .NotEmpty().WithMessage("El mensaje es obligatorio.")
                .MaximumLength(500).WithMessage("El mensaje debe tener como máximo 500 caracteres.");

            RuleFor(m => m.CreatedAt)
                .NotEmpty().WithMessage("La fecha de creación es obligatoria.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("La fecha de creación debe ser menor o igual a la fecha actual.");
        }


    }
}
