namespace ANCD.Domain.Services.Interfaces
{
    public interface ICacheService
    {
        Task SetCacheAsync(string key, object value, TimeSpan expirationFromNow);
        Task<T> GetFromCacheAsync<T>(string key) where T : class;
        Task RemoveFromCache(string key);
    }
}
