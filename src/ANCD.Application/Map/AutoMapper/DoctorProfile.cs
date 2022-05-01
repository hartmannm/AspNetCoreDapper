using ANCD.Application.Commands;
using ANCD.Application.DTOs;
using ANCD.Domain.Entities;
using ANCD.Domain.Entities.DomainEntities.Enums;
using ANCD.Domain.Entities.DomainEntities.ValueObjects;
using ANCD.Domain.Entities.ValueObjects;
using ANCD.Domain.Extensions;
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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Name(src.FirstName, src.LastName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => new CRMRegister(src.CRMUF.toEnum<EUF>(), src.CRMNumber)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalExams, opt => opt.Ignore());
        }

        private void DoctorToDoctorDTOMap()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => $"{src.CRM.Number}/{src.CRM.Uf}"));
        }
    }
}
