using ANCD.Domain.Entities;

namespace ANCD.Application.Data.Repositories
{
    public interface IPatientRepository
    {
        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> CreateAsync(Patient patient);

        Task<Patient> GetByIdAsync(Guid id);
    }
}
