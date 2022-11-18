using EntityFrameworkVehiculos.DTOs;
using FluentValidation;

namespace EntityFrameworkVehiculos.Utils
{
    public class SancionesValidator : AbstractValidator<SancionesDTO>
    {
        public SancionesValidator() 
        {
            RuleFor(s => s.Sancion).MaximumLength(100).WithMessage("Excede los 100 caracteres");
        }
    }
}
