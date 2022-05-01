using ANCD.Domain.Entities;
using ANCD.Domain.Entities.DomainEntities.Enums;

namespace ANCD.Application.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task CreateAsync(Doctor doctor);

        Task<bool> ExistsByEmailOrCRMAsync(string email, EUF crmUf, long crmNumber);
    }
}
