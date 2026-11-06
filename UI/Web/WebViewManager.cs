using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UI.Web.Routing;

namespace UI.Web;

public class WebViewManager(WebView2 _webView)
{
    public async void Initialize()
    {
        await _webView.EnsureCoreWebView2Async();

        string path;

        if (AppSettings.IsDevelopment)
        {
            path = $"http://localhost:{AppSettings.DevelopmentPort}";
        }
        else
        {
            _webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "cortex.local",
                Path.Combine(Application.StartupPath, "src", "dist"),
                CoreWebView2HostResourceAccessKind.Allow
            );

            path = "https://cortex.local/index.html";
        }

        _webView.CoreWebView2.NavigationCompleted += (s, args) =>
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

        var router = new WebMessageRouter(_webView);

        router.Initialize();

        _webView.CoreWebView2.Navigate(
           path
       );
    }
}
