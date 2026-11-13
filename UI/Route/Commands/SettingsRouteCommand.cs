using Business.Interfaces;
using Data.Services;
using UI.Route.Contract;
using UI.Web.Contract;

namespace UI.Route.Commands;

public class SettingsRouteCommand : IRouteCommand
{
    public string Route => "settings";
    
    public async Task<WebMessageResult> Execute()
    {
        ISettingService settingService = new SettingService();

        var settings = await settingService.GetAll();

        return new()
        {
            IsSuccess = true,
            Data = settings,
            Type = "settings"
        };
    }
}