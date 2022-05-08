using ANCD.Application.DTOs;
using ANCD.Application.Messages.Queries;

namespace ANCD.Application.Queries
{
    public sealed class GetDoctorByIdQuery : Query<DoctorDTO>
    {
        public Guid Id { get; init; }

        public GetDoctorByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
