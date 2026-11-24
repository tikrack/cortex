using Business.Interfaces;
using Data.Services;
using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using UI.Web.Contract;

namespace UI.Web.Commands.Knowledge;

public class AllKnowledgeCommand : IAsyncWebCommand
{
    public string Name => "all-knowledge";

    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        IKnowledgeService knowledgeService = new KnowledgeService();
        
        var knowledge = await knowledgeService.GetAll();

        webView.PostSuccess(
            type: Name,
            data: knowledge
        );
    }
}