using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.Map;
using ANCD.Application.Messages.CommandsQueries;
using ANCD.Domain.Entities;

namespace ANCD.Application.Commands.Handlers
{
    public class RegisterPatientCommandHandler : ICommandHandler<RegisterPatientCommand>
    {
        private readonly IMap _mapper;
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientCommandHandler(IMap mapper, IDataManager dataManager)
        {
            _mapper = mapper;
            _patientRepository = dataManager.PatientRepository;
        }

        public async Task<CommandResult> Handle(RegisterPatientCommand command, CancellationToken cancellationToken)
        {
            if (await _patientRepository.ExistsByEmailAsync(command.Email))
                return CommandResult.Fail("Paciente já cadastrado");

            var patient = _mapper.Map<Patient>(command);
            var isPatientRegistered = await _patientRepository.CreateAsync(patient);

            return isPatientRegistered ? CommandResult.Success() : CommandResult.Fail("Erro ao cadastrar paciente");
        }
    }
}
