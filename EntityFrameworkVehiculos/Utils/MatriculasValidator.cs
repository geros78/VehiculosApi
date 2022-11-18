using EntityFrameworkVehiculos.DTOs;
using FluentValidation;

namespace EntityFrameworkVehiculos.Utils
{
    public class MatriculasValidator : AbstractValidator<MatriculasDTO>
    {
        public MatriculasValidator() 
        {
            RuleFor(s => s.Numero).NotEmpty().WithMessage("El Numero es Obligatorio");
            RuleFor(s => s.Numero).MaximumLength(20).WithMessage("Excede los 20 caracteres");

            RuleFor(s => s.FechaExpedicion).NotEmpty().WithMessage("La Fecha de Expedicion es Obligatorio");

            RuleFor(s => s.ValidaHasta).NotEmpty().WithMessage("La Fecha de Validacion es Obligatorio");
        }
    }
}
