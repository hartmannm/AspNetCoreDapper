using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Commands.Handlers
{
    public class AccomplishMedicalExamCommandHandler : ICommandHandler<AccomplishMedicalExamCommand>
    {
        private readonly IMedicalExamRepository _medicalExamRepository;

        public AccomplishMedicalExamCommandHandler(IDataManager dataManager)
        {
            _medicalExamRepository = dataManager.MedicalExamRepository;
        }

        public async Task<CommandResult> Handle(AccomplishMedicalExamCommand command, CancellationToken cancellationToken)
        {
            var medicalExam = await _medicalExamRepository.GetByIdAsync(command.Id);

            if (medicalExam is null) return CommandResult.Fail("Exame médico não encontrado");

            if (medicalExam.IsAcomplished()) return CommandResult.Fail("Exame médico já está concluído");

            medicalExam.Accomplish();
            var isMedicalExamAccomplished = await _medicalExamRepository.Update(medicalExam);

            return isMedicalExamAccomplished ? CommandResult.Success() : CommandResult.Fail("Erro ao concluir exame médico");
        }
    }
}
