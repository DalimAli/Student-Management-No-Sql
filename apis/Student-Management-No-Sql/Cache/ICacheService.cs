namespace Student_Management_No_Sql.Cache;

public interface ICacheService
{
    Task<T> GetCachedDataAsync<T>(string key);
    Task SetCachedDataAsync<T>(string key, T data, TimeSpan cacheDuration);
    Task RemoveAsync(string key);
}