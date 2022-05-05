using ANCD.Domain.Entities;

namespace ANCD.Application.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task<bool> CreateAsync(Doctor doctor);

        Task<bool> ExistsByEmailOrCRMAsync(string email, string crmUf, long crmNumber);
    }
}
