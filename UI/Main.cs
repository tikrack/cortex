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

    private void Main_Load(object sender, EventArgs e)
    {
        var webViewManager = new WebViewManager(webView);

        webViewManager.Initialize();
    }
}
