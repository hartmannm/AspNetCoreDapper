using ANCD.Application.Commands;
using ANCD.Application.DTOs;
using ANCD.Domain.Entities;
using ANCD.Domain.Entities.DomainEntities.ValueObjects;
using AutoMapper;

namespace ANCD.Application.Map.AutoMapper
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            PatientToPatientDTOMap();
            RegisterPatientRequestToPatientMap();
        }

        private void PatientToPatientDTOMap()
        {
            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address));
        }

        private void RegisterPatientRequestToPatientMap()
        {
            CreateMap<RegisterPatientCommand, Patient>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Name(src.FirstName, src.LastName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalExams, opt => opt.Ignore());
        }
    }
}
