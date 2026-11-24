using Business.Entities;

namespace Business.Interfaces;

public interface ISettingService
{
    public Task<Setting> Get(string key);
    public Task<List<Setting>> GetAll();
    public Task UpdateValue(string key, string? value);
}