using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Commands
{
    public sealed class AccomplishMedicalExamCommand : Command
    {
        public Guid Id { get; init; }

        public AccomplishMedicalExamCommand(Guid id)
        {
            Id = id;
        }
    }
}
