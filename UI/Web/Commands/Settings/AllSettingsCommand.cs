using Business.Interfaces;
using Data.Services;
using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using UI.Web.Contract;

namespace UI.Web.Commands.Settings;

public class AllSettingsCommand : IAsyncWebCommand
{
    public string Name => "all-settings";

    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        ISettingService settingService = new SettingService();

        var settings = await settingService.GetAll();

        var result = new WebMessageResult()
        {
            IsSuccess = true,
            Data = settings,
            Type = this.Name
        };

        webView?.CoreWebView2.PostWebMessageAsJson(
            JsonSerializer.Serialize(
                result,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            )
        );
    }
}
