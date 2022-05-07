using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.Messages.CommandsQueries;
using ANCD.Domain.Entities;
using ANCD.Domain.Extensions;

namespace ANCD.Application.Commands.Handlers
{
    public class ScheduleMedicalExamCommandHandler : ICommandHandler<ScheduleMedicalExamCommand>
    {
        private readonly IMedicalExamRepository _medicalExamRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public ScheduleMedicalExamCommandHandler(IDataManager dataManager)
        {
            _medicalExamRepository = dataManager.MedicalExamRepository;
            _patientRepository = dataManager.PatientRepository;
            _doctorRepository = dataManager.DoctorRepository;
        }

        public async Task<CommandResult> Handle(ScheduleMedicalExamCommand command, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(command.PatientId);
            var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);
            var doctorOrPatientDontExistsValidationResult = ValidateDoctorAndPatient(doctor, patient);

            if (doctorOrPatientDontExistsValidationResult.Any()) return CommandResult.Fail(doctorOrPatientDontExistsValidationResult);

            var exam = new MedicalExam(command.Date, doctor, patient);
            var agendaConflictValidationResult = await ValidateExamAgendaConflict(exam);

            if (agendaConflictValidationResult.Any()) return CommandResult.Fail(agendaConflictValidationResult);

            var isMedicalExamScheduled = await _medicalExamRepository.ScheduleAsync(exam);

            return isMedicalExamScheduled ? CommandResult.Success() : CommandResult.Fail("Erro ao agendar exame médico");
        }

        private ICollection<string> ValidateDoctorAndPatient(Doctor doctor, Patient patient)
        {
            if (doctor is not null && patient is not null)
                return Enumerable.Empty<string>().ToList();

            var errors = new List<string>();
            errors.AddConditionally("Paciente não encontrado", () => patient is null);
            errors.AddConditionally("Médico não encontrado", () => doctor is null);

            return errors;
        }

        private async Task<ICollection<string>> ValidateExamAgendaConflict(MedicalExam exam)
        {
            var result = new List<string>();

            if (await IsDoctorExamsScheduledInSameTime(exam))
                result.Add("Médico já possui um exame agendado na mesma data e horário");

            if (await IsPatientExamsScheduledInSameTime(exam))
                result.Add("Paciente já possui um exame agendado na mesma data e horário");

            return result;
        }

        private async Task<bool> IsDoctorExamsScheduledInSameTime(MedicalExam exam)
        {
            var scheduledExams = await _medicalExamRepository.GetMedicalExamsByDateAndDoctorIdAsync(exam.Date, exam.DoctorId);

            return scheduledExams.Any() ? scheduledExams.Any(x => exam.HasDateConflict(x)) : false;
        }

        private async Task<bool> IsPatientExamsScheduledInSameTime(MedicalExam exam)
        {
            var scheduledExams = await _medicalExamRepository.GetMedicalExamsByDateAndPatientIdAsync(exam.Date, exam.PatientId);

            return scheduledExams.Any() ? scheduledExams.Any(x => exam.HasDateConflict(x)) : false;
        }
    }
}
