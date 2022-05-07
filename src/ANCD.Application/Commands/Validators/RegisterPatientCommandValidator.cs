using FluentValidation;

namespace ANCD.Application.Commands.Validators
{
    public class RegisterPatientCommandValidator : AbstractValidator<RegisterPatientCommand>
    {
        public RegisterPatientCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Informe o nome do paciente");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Informe o sobrenome do mpacienteédico");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Informe o email do paciente")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.UtcNow)
                .WithMessage("A data de nascimento deve ser menor que a data atual");
        }
    }
}
