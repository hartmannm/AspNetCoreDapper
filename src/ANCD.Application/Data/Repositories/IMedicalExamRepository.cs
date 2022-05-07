using ANCD.Domain.Entities;

namespace ANCD.Application.Data.Repositories
{
    public interface IMedicalExamRepository
    {
        Task<bool> ScheduleAsync(MedicalExam exam);

        Task<IEnumerable<MedicalExam>> GetMedicalExamsByDateAndDoctorIdAsync(DateTime date, Guid doctorId);

        Task<IEnumerable<MedicalExam>> GetMedicalExamsByDateAndPatientIdAsync(DateTime date, Guid patientId);
    }
}
