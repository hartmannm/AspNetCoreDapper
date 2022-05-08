using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Domain.Extensions;
using ANCD.Infra.Data.SQLParameters;
using Dapper;

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

        public async Task<IEnumerable<MedicalExam>> GetMedicalExamsByDateAndDoctorIdAsync(DateTime date, Guid doctorId)
        {
            var parameters = new { Date = date.ToSQLDateOnlyQuery(), DoctorId = doctorId };
            var sql = @"SELECT Id, [Date], DoctorId, PatientId, [Status]
                        FROM MedicalExams WHERE CAST([Date] as Date) = @Date AND DoctorId = @DoctorId";

            return await GetConnection().QueryAsync<MedicalExam>(sql, parameters);
        }

        public async Task<IEnumerable<MedicalExam>> GetMedicalExamsByDateAndPatientIdAsync(DateTime date, Guid patientId)
        {
            var parameters = new { Date = date.ToSQLDateOnlyQuery(), PatientId = patientId };
            var sql = @"SELECT Id, [Date], DoctorId, PatientId, [Status]
                        FROM MedicalExams WHERE CAST([Date] as Date) = @Date AND PatientId = @PatientId";

            return await GetConnection().QueryAsync<MedicalExam>(sql, parameters);
        }

        public async Task<MedicalExam> GetByIdAsync(Guid id)
        {
            var parameters = new { Id = id };
            var sql = @"SELECT me.Id, me.[Date], me.DoctorId, me.PatientId, me.[Status], 
                            d.Id, d.FirstName, d.LastName, d.Email, d.CrmUf, d.CrmNumber, d.CrmNumber,  
                            p.Id, p.FirstName, p.LastName, p.Email, p.BirthDate  
                        FROM MedicalExams me
                            INNER JOIN Doctors d 
                                ON me.DoctorId = d.Id
                            INNER JOIN Patients p
                                ON me.PatientId = p.Id
                        WHERE me.Id = @Id";
            var medicalExams = await GetConnection().QueryAsync<MedicalExam, Doctor, Patient, MedicalExam>(sql, (medicalExam, doctor, patient) =>
            {
                medicalExam.SetDoctor(doctor);
                medicalExam.SetPatient(patient);
                return medicalExam;
            },
            parameters);

            return medicalExams.FirstOrDefault();
        }

        public async Task<bool> Update(MedicalExam exam)
        {
            var parameters = new UpdateMedicalExamParameters(exam);
            var sql = @"UPDATE MedicalExams SET [Date] = @Date, DoctorId = @DoctorId, PatientId = @Patientid, Status = @Status
                        WHERE Id = @Id";

            return await ExecuteInTransactionAsync(sql, parameters);
        }
    }
}
