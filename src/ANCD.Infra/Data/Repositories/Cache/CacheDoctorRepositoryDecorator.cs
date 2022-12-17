using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Domain.Services.Interfaces;

namespace ANCD.Infra.Data.Repositories.Cache
{
    public class CacheDoctorRepositoryDecorator<T> : IDoctorRepository where T : IDoctorRepository
    {
        private readonly ICacheService _cacheService;
        private readonly T _inner;

        public CacheDoctorRepositoryDecorator(ICacheService cacheService, T inner)
        {
            _cacheService = cacheService;
            _inner = inner;
        }

        public async Task<bool> CreateAsync(Doctor doctor) => await _inner.CreateAsync(doctor); 

        public async Task<bool> ExistsByEmailOrCRMAsync(string email, string crmUf, long crmNumber)
        {
            return await _inner.ExistsByEmailOrCRMAsync(email, crmUf, crmNumber);
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            var key = $"{nameof(Doctor)}-{id}";
            var doctor = await _cacheService.GetFromCacheAsync<Doctor>(key);

            if (doctor is not null) return doctor;

            doctor = await _inner.GetByIdAsync(id);
            await _cacheService.SetCacheAsync(key, doctor, TimeSpan.FromHours(12));

            return doctor;
        }
    }
}
