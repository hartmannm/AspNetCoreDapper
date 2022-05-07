using FluentValidation;

namespace ANCD.Application.Commands.Validators
{
    public class ScheduleMedicalExamCommandValidator : AbstractValidator<ScheduleMedicalExamCommand>
    {
        public ScheduleMedicalExamCommandValidator()
        {
            RuleFor(x => x.DoctorId)
                .NotEmpty()
                .WithMessage("Informe o médico");

            RuleFor(x => x.PatientId)
                .NotEmpty()
                .WithMessage("Informe o paciente");

            RuleFor(x => x.Date)
                .GreaterThanOrEqualTo(x => DateTime.Now)
                .WithMessage("A data da consulta deve ser igual ou superior a data atual");
        }
    }
}
