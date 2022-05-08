using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.DTOs;
using ANCD.Application.Map;
using ANCD.Application.Messages.Queries;

namespace ANCD.Application.Queries.Handlers
{
    public class GetMedicalExamByIdQueryHandler : IQueryHandler<GetMedicalExamByIdQuery, MedicalExamDTO>
    {
        private readonly IMedicalExamRepository _medicalExamRepository;
        private readonly IMap _mapper;

        public GetMedicalExamByIdQueryHandler(IDataManager dataManager, IMap mapper)
        {
            _medicalExamRepository = dataManager.MedicalExamRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<MedicalExamDTO>> Handle(GetMedicalExamByIdQuery query, CancellationToken cancellationToken)
        {
            var medicalExam = await _medicalExamRepository.GetByIdAsync(query.Id);
            var result = medicalExam is null ? null : _mapper.Map<MedicalExamDTO>(medicalExam);

            return QueryResult<MedicalExamDTO>.Success(result);
        }
    }
}
