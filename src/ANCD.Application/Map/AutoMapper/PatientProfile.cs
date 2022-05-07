using ANCD.Application.Commands;
using ANCD.Application.DTOs;
using ANCD.Domain.Entities;
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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }

        private void RegisterPatientRequestToPatientMap()
        {
            CreateMap<RegisterPatientCommand, Patient>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalExams, opt => opt.Ignore());
        }
    }
}
