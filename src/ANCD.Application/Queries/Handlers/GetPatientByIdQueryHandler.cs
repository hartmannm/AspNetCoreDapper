using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.DTOs;
using ANCD.Application.Map;
using ANCD.Application.Messages.Queries;

namespace ANCD.Application.Queries.Handlers
{
    public class GetPatientByIdQueryHandler : IQueryHandler<GetPatientByIdQuery, PatientDTO>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMap _mapper;

        public GetPatientByIdQueryHandler(IDataManager dataManager, IMap mapper)
        {
            _patientRepository = dataManager.PatientRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<PatientDTO>> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(query.Id);
            var result = patient is null ? null : _mapper.Map<PatientDTO>(patient);

            return QueryResult<PatientDTO>.Success(result);
        }
    }
}
