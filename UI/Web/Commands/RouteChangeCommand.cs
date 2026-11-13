using System.Text.Json;
using Microsoft.Web.WebView2.WinForms;
using UI.Route.Routing;
using UI.Web.Contract;

namespace UI.Web.Commands;

public class RouteChangeCommand : IAsyncWebCommand
{
    public string Name => "route-change";

    public async Task ExecuteAsync(JsonElement data, WebView2? webView)
    {
        var route = data.GetProperty("route").GetString();

        if (route == null)
            throw new Exception($"Route address of {this.Name} command, not set!");

        var router = new RouteMessageRouter();
        
        var result = await router.Handle(route);

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