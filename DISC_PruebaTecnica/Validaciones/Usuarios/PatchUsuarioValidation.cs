using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Validaciones.Mensajes;
using FluentValidation;

namespace DISC_PruebaTecnica.Validaciones.Usuarios
{
    public class PatchUsuarioValidation : AbstractValidator<UserDto>
    {
        public PatchUsuarioValidation()
        {
            RuleFor(x => x.IdRol).Cascade(CascadeMode.Stop).GreaterThanOrEqualTo(1).WithMessage(Utils.MensajesValidacion("Id Rol", 5) + Utils.Sugerencia(3));
            RuleFor(x => x.IdPuesto).Cascade(CascadeMode.Stop).GreaterThanOrEqualTo(1).WithMessage(Utils.MensajesValidacion("Id Rol", 5) + Utils.Sugerencia(3));



            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotNull().WithMessage(Utils.MensajesValidacion("Correo electrónico", 1) + Utils.Sugerencia(4)).NotEmpty().WithMessage(Utils.MensajesValidacion("Correo electrónico", 2) + Utils.Sugerencia(4)).Matches(RegularExpressions.mailValidation).WithMessage((Utils.MensajesValidacion("Correo electrónico", 3) + Utils.Sugerencia(4)));
            RuleFor(x => x.Usuario).Cascade(CascadeMode.Stop).NotNull().WithMessage(Utils.MensajesValidacion("Usuario", 1) + Utils.Sugerencia(6)).NotEmpty().WithMessage(Utils.MensajesValidacion("Usuario", 2) + Utils.Sugerencia(6)).Matches(RegularExpressions.nombreUsuarioValidation).WithMessage((Utils.MensajesValidacion("Usuario", 3) + Utils.Sugerencia(6)));
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop).NotNull().WithMessage(Utils.MensajesValidacion("Password", 1) + Utils.Sugerencia(7)).NotEmpty().WithMessage(Utils.MensajesValidacion("Password", 2) + Utils.Sugerencia(7)).Matches(RegularExpressions.contraseniaValidation).WithMessage((Utils.MensajesValidacion("Password", 3) + Utils.Sugerencia(7))).Matches(RegularExpressions.longitudContraseniaValidation).WithMessage((Utils.MensajesValidacion("Password", 3) + Utils.Sugerencia(7)));
        }
    }
}
