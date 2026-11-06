using System.Text.Json;
using UI.Web.Contract;

namespace UI.Web.Commands;

public class RouteChangeCommand : IWebCommand
{
    public string Name => "route-change";
    
    public void Execute(JsonElement data)
    {
        
    }
}