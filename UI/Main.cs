using Microsoft.Web.WebView2.Core;
using System.Text.Json;
using UI.Web;

namespace UI;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private async void Main_Load(object sender, EventArgs e)
    {
        var webViewManager = new WebViewManager(webView);

        await webViewManager.Initialize();
    }
}
