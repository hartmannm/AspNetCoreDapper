using ANCD.Application.DTOs;
using ANCD.Application.Messages.Queries;

namespace ANCD.Application.Queries
{
    public sealed class GetPatientByIdQuery : Query<PatientDTO>
    {
        public Guid Id { get; init; }

        public GetPatientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
