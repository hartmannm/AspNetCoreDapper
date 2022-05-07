using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Commands
{
    public sealed class RegisterPatientCommand : Command
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public DateTime BirthDate { get; init; }
    }
}
