using System.Text.Json;
using UI.Web.Contract;

namespace UI.Route.Contract;

public interface IRouteCommand
{
    string Route { get; }
    
    Task<WebMessageResult> Execute();
}