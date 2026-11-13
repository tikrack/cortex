using System.Text.Json;
using Microsoft.Web.WebView2.WinForms;
using UI.Web.Contract;

namespace UI.Web.Commands;

public class RouteChangeCommand : IWebCommand
{
    public string Name => "route-change";

    public void Execute(JsonElement data, WebView2? webView)
    {
        var route = data.GetProperty("route").GetString();

        if (route == null)
            throw new Exception($"Route address of {this.Name} command, not set!");

        
    }
}