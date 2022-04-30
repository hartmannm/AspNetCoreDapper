using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Commands
{
    public sealed class RegisterDoctorCommand : Command
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string CRMUF { get; init; }

        public long CRMNumber { get; init; }
    }
}
