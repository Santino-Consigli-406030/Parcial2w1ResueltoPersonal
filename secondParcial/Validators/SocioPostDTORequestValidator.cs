using FluentValidation;
using secondParcial.DTOS;

namespace secondParcial.Validators
{
    public class SocioPostDTORequestValidator:AbstractValidator<SocioPostDTORequest>
    {
        public SocioPostDTORequestValidator() { 
            RuleFor(x=> x.Nombre).NotEmpty().WithMessage("El nombre del socio es requerido");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El Apellido del socio es requerido");
            RuleFor(x => x.Email).NotEmpty().WithMessage("El Email del socio es requerido");
            RuleFor(x => x.IdDeporte).NotEmpty().WithMessage("El deporte del socio es requerido");
            RuleFor(x => x.Dni).NotEmpty().WithMessage("El dni del socio es requerido");
        
        }
    }
}
