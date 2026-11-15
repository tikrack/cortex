using Microsoft.Web.WebView2.Core;
using System.Text.Json;
using UI.Web;

namespace UI;

public partial class Main : Form
{
    ContextMenuStrip trayMenu;

    public Main()
    {
        InitializeComponent();
    }

    private async void Main_Load(object sender, EventArgs e)
    {
        trayMenu = new ContextMenuStrip();

        var closeTool = new ToolStripMenuItem("Close");
        closeTool.Click += (sender, e) => Application.Exit();

        trayMenu.Items.Add(closeTool);

        notifyIcon.ContextMenuStrip = trayMenu;

        var webViewManager = new WebViewManager(webView);

        await webViewManager.Initialize();
    }



    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Hide();
            e.Cancel = true;
            notifyIcon.Visible = true;
        }
    }

    private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            trayMenu.Show(Cursor.Position);
            return;
        }

        Show();
        Activate();
    }
}
