using System.Text.Json;
using Microsoft.Web.WebView2.WinForms;

namespace UI.Web.Contract;

public interface IAsyncWebCommand
{
    string Name { get; }
    
    Task ExecuteAsync(JsonElement? data, WebView2? webView);
}