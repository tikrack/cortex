using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using UI.Web.Registry;

namespace UI.Web.Routing;

public class WebMessageRouter(WebView2 _webView)
{
    public void Initialize()
    {
        _webView.CoreWebView2.WebMessageReceived += (sender, e) =>
        {

            var message = JsonSerializer.Deserialize<JsonElement>(
                e.WebMessageAsJson
            );

            var method = message.GetProperty("method").GetString();

            var route = message.GetProperty("route").GetString();

            var registry = CommandRegistry.Instance;

            var command = registry.Get(route ?? "");

            command.Execute(message.GetProperty("data"));
        };
    }
}
