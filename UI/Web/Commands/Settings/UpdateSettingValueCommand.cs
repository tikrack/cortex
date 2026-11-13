using Business.Entities;
using Business.Interfaces;
using Data.Services;
using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using UI.Web.Contract;

namespace UI.Web.Commands.Settings;

public class UpdateSettingValueCommand : IAsyncWebCommand
{
    public string Name => "update-setting-value";

    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        var key = data?.GetProperty("key").GetString();
        
        var value = data?.GetProperty("value").GetString();

        if (key == null) return;

        ISettingService settingService = new SettingService();

        await settingService.UpdateValue(key, value);

        var allSettingCommand = new AllSettingsCommand();

        await allSettingCommand.ExecuteAsync(null, webView);
    }
}
