using ANCD.Application.DTOs;
using ANCD.Domain.Entities;
using AutoMapper;

namespace ANCD.Application.Map.AutoMapper
{
    public class MedicalExamProfile : Profile
    {
        public MedicalExamProfile()
        {
            MedicalExamToMedicalExamDTOMap();
        }

        private void MedicalExamToMedicalExamDTOMap()
        {
            CreateMap<MedicalExam, MedicalExamDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
