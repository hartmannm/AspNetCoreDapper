using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Application.DTOs;
using ANCD.Application.Map;
using ANCD.Application.Messages.Queries;
using ANCD.Domain.Entities;
using ANCD.Domain.Services.Interfaces;

namespace ANCD.Application.Queries.Handlers
{
    public class GetDoctorByIdQueryHandler : IQueryHandler<GetDoctorByIdQuery, DoctorDTO>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMap _mapper;

        public GetDoctorByIdQueryHandler(IDataManager dataManager, IMap mapper)
        {
            _doctorRepository = dataManager.DoctorRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<DoctorDTO>> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(query.Id);
            var result = doctor is null ? null : _mapper.Map<DoctorDTO>(doctor);

            return QueryResult<DoctorDTO>.Success(result);
        }
    }
}
