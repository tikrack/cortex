using System.Text.Json;
using Microsoft.Web.WebView2.WinForms;
using UI.Web.Contract;

namespace UI.Web;

public static class WebViewExtenstionMethods
{
    public static void PostError(this WebView2? webView, string? message = null, List<string>? errors = null)
    {
        webView?.CoreWebView2.PostWebMessageAsJson(
            JsonSerializer.Serialize(
                new WebMessageResult()
                {
                    Message = message,
                    Errors = errors
                },
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            )
        );
    }
    
    public static void PostSuccess(this WebView2? webView, string type, string? message = null, object? data = null)
    {
        webView?.CoreWebView2.PostWebMessageAsJson(
            JsonSerializer.Serialize(
                new WebMessageResult()
                {
                    IsSuccess = true,
                    Data = data,
                    Message = message,
                    Type = type
                },
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            )
        );
    }
}