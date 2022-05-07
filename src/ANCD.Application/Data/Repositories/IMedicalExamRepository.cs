using ANCD.Domain.Entities;

namespace ANCD.Application.Data.Repositories
{
    public interface IMedicalExamRepository
    {
        Task<bool> ScheduleAsync(MedicalExam exam);
    }
}
