using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Infra.Data.SQLParameters;
using Dapper;

namespace ANCD.Infra.Data.Repositories
{
    public class PatientRepository : AbstractRepository, IPatientRepository
    {
        public PatientRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CreateAsync(Patient patient)
        {
            var parameters = new RegisterPatientParameters(patient);
            var sql = @"INSERT INTO Patients (Id, FirstName, LastName, Email, BirthDate)
                        VALUES (@Id, @FirstName, @LastName, @Email, @BirthDate)";

            return await ExecuteInTransactionAsync(sql, parameters);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var parameters = new { Email = email };
            var sql = @"SELECT 1 FROM Patients 
                        WHERE Email = @email";

            return await GetConnection().ExecuteScalarAsync<bool>(sql, parameters);
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var parameters = new { Id = id };
            var sql = @"SELECT Id, FirstName, LastName, Email, BirthDate FROM Patients
                        WHERE Id = @Id";

            return await GetConnection().QuerySingleOrDefaultAsync<Patient>(sql, parameters);
        }
    }
}
