using Business.Entities;

namespace Business.Interfaces;

public interface ISettingService
{
    public Task<List<Setting>> GetAll();
}