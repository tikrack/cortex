using System.Text.Json;
using Business.Interfaces;
using Data.Services;
using Microsoft.Web.WebView2.WinForms;
using UI.Web.Contract;

namespace UI.Web.Commands.Knowledge;

public class DeleteKnowledgeCommand : IAsyncWebCommand
{
    public string Name => "delete-knowledge";
    
    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        var id = data?.GetProperty("id").GetString();

        if (id == null)
            return;
        
        IKnowledgeService knowledgeService = new KnowledgeService();

        await knowledgeService.Delete(Guid.Parse(id));
        
        webView.PostSuccess(
            type: Name,
            message: "Delete knowledge successfully."
        );
    }
}