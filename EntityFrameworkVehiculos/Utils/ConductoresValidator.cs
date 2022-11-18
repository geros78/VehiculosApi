using EntityFrameworkVehiculos.DTOs;
using FluentValidation;

namespace EntityFrameworkVehiculos.Utils
{
    public class ConductoresValidator : AbstractValidator<ConductoresDTO>
    {
        public ConductoresValidator() 
        {
            RuleFor(s => s.Identificacion).NotEmpty().WithMessage("La Identificacion es Obligatorio");
            RuleFor(s => s.Identificacion).MaximumLength(15).WithMessage("Excede los 20 caracteres");

            RuleFor(s => s.Nombre).NotEmpty().WithMessage("El Nombre es Obligatorio");
            RuleFor(s => s.Nombre).MaximumLength(20).WithMessage("Excede los 20 caracteres");

            RuleFor(s => s.Apellido).NotEmpty().WithMessage("El Apellido es Obligatorio");
            RuleFor(s => s.Apellido).MaximumLength(30).WithMessage("Excede los 30 caracteres");

            RuleFor(s => s.Direccion).MaximumLength(15).WithMessage("Excede los 15 caracteres");

            RuleFor(s => s.Direccion).MaximumLength(15).WithMessage("Excede los 15 caracteres");

            RuleFor(s => s.Email).MaximumLength(30).WithMessage("Excede los 30 caracteres");
        }
    }
}
