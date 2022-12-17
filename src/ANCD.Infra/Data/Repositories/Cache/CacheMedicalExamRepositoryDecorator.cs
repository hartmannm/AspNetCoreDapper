using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;
using ANCD.Domain.Services.Interfaces;

namespace ANCD.Infra.Data.Repositories.Cache
{
    public class CacheMedicalExamRepositoryDecorator<T> : IMedicalExamRepository where T : IMedicalExamRepository
    {
        private readonly ICacheService _cacheService;
        private readonly T _inner;

        public CacheMedicalExamRepositoryDecorator(ICacheService cacheService, T inner)
        {
            _cacheService = cacheService;
            _inner = inner;
        }

        public async Task<bool> ScheduleAsync(MedicalExam exam) => await _inner.ScheduleAsync(exam);

        public async Task<IEnumerable<MedicalExam>> GetMedicalExamsByDateAndDoctorIdAsync(DateTime date, Guid doctorId)
        {
            return await _inner.GetMedicalExamsByDateAndDoctorIdAsync(date, doctorId);
        }

        public async Task<IEnumerable<MedicalExam>> GetMedicalExamsByDateAndPatientIdAsync(DateTime date, Guid patientId)
        {
            return await _inner.GetMedicalExamsByDateAndPatientIdAsync(date, patientId);
        }

        public async Task<MedicalExam> GetByIdAsync(Guid id)
        {
            var key = GetExamIdKey(id);
            var exam = await _cacheService.GetFromCacheAsync<MedicalExam>(key);

            if (exam is not null) return exam;

            exam = await _inner.GetByIdAsync(id);
            await _cacheService.SetCacheAsync(key, exam, TimeSpan.FromHours(12));

            return exam;
        }

        public async Task<bool> UpdateAsync(MedicalExam exam)
        {
            var key = GetExamIdKey(exam.Id);
            await _cacheService.RemoveFromCache(key);

            return await _inner.UpdateAsync(exam);
        }

        private string GetExamIdKey(Guid id) => $"{nameof(MedicalExam)}-{id}";
    }
}
