using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using UI.Web.Registry;

namespace UI.Web.Routing;

public class WebMessageRouter(WebView2 webView)
{
    public void Initialize()
    {
        webView.CoreWebView2.WebMessageReceived += (sender, e) =>
        {
            var message = JsonSerializer.Deserialize<JsonElement>(
                e.WebMessageAsJson
            );

            var method = message.GetProperty("method").GetString();
            
            var registry = CommandRegistry.Instance;

            var command = registry.Get(method ?? "");

            if (command == null) return;
            
            command?.Execute(message.GetProperty("data"), sender as WebView2);
        };
    }
}
