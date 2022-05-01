using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Domain.Entities.DomainEntities.Enums;

namespace ANCD.Infra.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public Task CreateAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByEmailOrCRMAsync(string email, EUF crmUf, long crmNumber)
        {
            throw new NotImplementedException();
        }
    }
}
