using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using UI.Web.Contract;
using UI.Web.Registry;

namespace UI.Web.Routing;

public class WebMessageRouter(WebView2 webView)
{
    public void Initialize()
    {
        webView.CoreWebView2.WebMessageReceived += async (sender, e) =>
        {
            var message = JsonSerializer.Deserialize<JsonElement>(
                e.WebMessageAsJson
            );

            var method = message.GetProperty("method").GetString();
            
            var registry = WebCommandRegistry.Instance;

            var command = registry.Get(method ?? "");

            if (command == null) return;

            JsonElement data;

            var status = message.TryGetProperty("data", out data);

            switch (command)
            {
                case IWebCommand webCommand:
                    webCommand.Execute(
                        status ? data : null,
                        webView
                    );
                    break;
                
                case IAsyncWebCommand webCommandAsync:
                    await webCommandAsync.ExecuteAsync(
                        status ? data : null,
                        webView
                    );
                    break;
            }
        };
    }
}
