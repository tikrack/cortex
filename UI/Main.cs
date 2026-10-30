using Microsoft.Web.WebView2.Core;

namespace UI;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private async void Main_Load(object sender, EventArgs e)
    {
        await webView.EnsureCoreWebView2Async();

        string path;

        if (AppSettings.IsDevelopment)
        {
            path = $"http://localhost:{AppSettings.DevelopmentPort}";
        }else
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

        webView.CoreWebView2.Navigate(
            path
        );
    }
}
