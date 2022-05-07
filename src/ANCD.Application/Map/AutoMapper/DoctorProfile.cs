using ANCD.Application.Commands;
using ANCD.Application.DTOs;
using ANCD.Domain.Entities;
using AutoMapper;

namespace ANCD.Application.Map.AutoMapper
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            RegisterDoctorRequestToDoctorMap();
            DoctorToDoctorDTOMap();
        }

        private void RegisterDoctorRequestToDoctorMap()
        {
            CreateMap<RegisterDoctorCommand, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalExams, opt => opt.Ignore());
        }

        private void DoctorToDoctorDTOMap()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => $"{src.CRMNumber}/{src.CRMUf}"));
        }
    }
}
