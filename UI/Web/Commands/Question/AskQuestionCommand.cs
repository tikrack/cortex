using System.Text.Json;
using Microsoft.Web.WebView2.WinForms;
using UI.Web.Contract;

namespace UI.Web.Commands.Question;

public class AskQuestionCommand : IAsyncWebCommand
{
    public string Name => "ask-question";
    
    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        var id = data?.GetProperty("id").GetString();
        
        bool isNewQuestion = id == null;
        
        

    }
}