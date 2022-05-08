using ANCD.Application.DTOs;
using ANCD.Application.Messages.Queries;

namespace ANCD.Application.Queries
{
    public sealed class GetMedicalExamByIdQuery : Query<MedicalExamDTO>
    {
        public Guid Id { get; init; }

        public GetMedicalExamByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
