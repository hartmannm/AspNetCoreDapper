using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Commands
{
    public sealed class ScheduleMedicalExamCommand : Command
    {
        public Guid DoctorId { get; init; }

        public Guid PatientId { get; init; }

        public DateTime Date { get; init; }
    }
}
