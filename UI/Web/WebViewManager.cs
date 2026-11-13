using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using UI.Route.Registry;
using UI.Web.Registry;
using UI.Web.Routing;

namespace UI.Web;

public class WebViewManager(WebView2 webView)
{
    public async Task Initialize()
    {
        await webView.EnsureCoreWebView2Async();

        string path;

        if (AppSettings.IsDevelopment)
        {
            path = $"http://localhost:{AppSettings.DevelopmentPort}";
        }
        else
        {
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "cortex.local",
                Path.Combine(Application.StartupPath, "src", "dist"),
                CoreWebView2HostResourceAccessKind.Allow
            );

            path = "https://cortex.local/index.html";
        }

        webView.CoreWebView2.NavigationCompleted += (s, args) =>
        {
            if (!args.IsSuccess)
            {
                MessageBox.Show(
                    "An issue has occurred while running the program.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        };

        (new WebCommandRegistrator()).Register();
        (new RouteCommandRegistrator()).Register();

        var router = new WebMessageRouter(webView);
        router.Initialize();

        webView.CoreWebView2.Navigate(
           path
       );
    }
}
