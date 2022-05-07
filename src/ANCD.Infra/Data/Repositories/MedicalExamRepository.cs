using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Infra.Data.SQLParameters;

namespace ANCD.Infra.Data.Repositories
{
    public class MedicalExamRepository : AbstractRepository, IMedicalExamRepository
    {
        public MedicalExamRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ScheduleAsync(MedicalExam exam)
        {
            var parameters = new ScheduleMedicalExamParameters(exam);
            var sql = @"INSERT INTO MedicalExams (Id, Date, DoctorId, PatientId, Status)
                        VALUES (@Id, @Date, @DoctorId, @PatientId, @Status)";

            return await ExecuteInTransactionAsync(sql, parameters);
        }
    }
}
