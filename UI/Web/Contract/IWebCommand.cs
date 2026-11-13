using System.Text.Json;
using Microsoft.Web.WebView2.WinForms;

namespace UI.Web.Contract;

public interface IWebCommand
{
    string Name { get; }
    void Execute(JsonElement data, WebView2? webView);
}
