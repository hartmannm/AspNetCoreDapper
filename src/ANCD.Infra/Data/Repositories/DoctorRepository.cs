using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Infra.Data.SQLParameters;
using Dapper;

namespace ANCD.Infra.Data.Repositories
{
    public class DoctorRepository : AbstractRepository, IDoctorRepository
    {
        public DoctorRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CreateAsync(Doctor doctor)
        {
            var parameters = new RegisterDoctorParameters(doctor);
            var sql = @"INSERT INTO Doctors (Id, FirstName, LastName, Email, CrmUf, CrmNumber)
                        VALUES (@Id, @FirstName, @LastName, @Email, @CrmUf, @CrmNumber)";

            return await ExecuteInTransactionAsync(sql, parameters);
        }

        public async Task<bool> ExistsByEmailOrCRMAsync(string email, string crmUf, long crmNumber)
        {
            var parameters = new DoctorExistsByEmailOrCRMParameters(email, crmUf, crmNumber);
            var sql = @"SELECT 1 FROM Doctors 
                        WHERE Email = @email OR (Crmuf = @crmUf AND CrmNumber = @crmNumber)";

            return await GetConnection().ExecuteScalarAsync<bool>(sql, parameters);
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            var parameters = new { Id = id };
            var sql = @"SELECT Id, FirstName, LastName, Email, CrmUf, CrmNumber FROM Doctors
                        WHERE Id = @Id";

            return await GetConnection().QuerySingleOrDefaultAsync<Doctor>(sql, parameters);
        }
    }
}
