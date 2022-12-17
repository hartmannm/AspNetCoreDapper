using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Domain.Services.Interfaces;

namespace ANCD.Infra.Data.Repositories.Cache
{
    public class CachePatientRepositoryDecorator<T> : IPatientRepository where T : IPatientRepository
    {
        private readonly ICacheService _cacheService;
        private readonly T _inner;

        public CachePatientRepositoryDecorator(ICacheService cacheService, T inner)
        {
            _cacheService = cacheService;
            _inner = inner;
        }

        public async Task<bool> CreateAsync(Patient patient) => await _inner.CreateAsync(patient);

        public async Task<bool> ExistsByEmailAsync(string email) => await _inner.ExistsByEmailAsync(email);

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var key = $"{nameof(Patient)}-{id}";
            var patient = await _cacheService.GetFromCacheAsync<Patient>(key);

            if (patient is not null) return patient;

            patient = await _inner.GetByIdAsync(id);
            await _cacheService.SetCacheAsync(key, patient, TimeSpan.FromHours(12));

            return patient;
        }
    }
}
