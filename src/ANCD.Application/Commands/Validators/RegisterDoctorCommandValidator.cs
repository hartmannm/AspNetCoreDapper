using ANCD.Domain.Entities.DomainEntities.Enums;
using FluentValidation;

namespace ANCD.Application.Commands.Validators
{
    public class RegisterDoctorCommandValidator : AbstractValidator<RegisterDoctorCommand>
    {
        public RegisterDoctorCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Informe o nome do médico");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Informe o sobrenome do médico");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Informe o email do médico")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.CRMUF)
                .IsEnumName(typeof(EUF), caseSensitive: false)
                .WithMessage("UF do CRM inválido");

            RuleFor(x => x.CRMNumber)
                .NotEmpty()
                .WithMessage("Informe o registro do CRM");
        }
    }
}
