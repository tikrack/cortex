using Business.Entities;

namespace Business.Interfaces;

public interface ISettingService
{
    public Task<List<Setting>> GetAll();
    public Task UpdateValue(string Key, string? Value);
}