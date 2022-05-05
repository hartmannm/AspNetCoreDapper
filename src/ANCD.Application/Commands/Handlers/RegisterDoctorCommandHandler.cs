using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.Map;
using ANCD.Application.Messages.CommandsQueries;
using ANCD.Domain.Entities;

namespace ANCD.Application.Commands.Handlers
{
    public class RegisterDoctorCommandHandler : ICommandHandler<RegisterDoctorCommand>
    {
        private readonly IMap _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public RegisterDoctorCommandHandler(IMap mapper, IDataManager dataManager)
        {
            _mapper = mapper;
            _doctorRepository = dataManager.DoctorRepository;
        }

        public async Task<CommandResult> Handle(RegisterDoctorCommand command, CancellationToken cancellationToken)
        {
            var isDoctorExists = await _doctorRepository.ExistsByEmailOrCRMAsync(command.Email, command.CRMUF, command.CRMNumber);

            if (isDoctorExists)
                return CommandResult.Fail("Doutor já cadastrado");

            var doctor = _mapper.Map<Doctor>(command);
            var isDoctorRegistered = await _doctorRepository.CreateAsync(doctor);

            return isDoctorRegistered ? CommandResult.Success() : CommandResult.Fail("Erro ao cadastrar doutor");
        }
    }
}
