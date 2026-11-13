using UI.Route.Registry;
using UI.Web.Contract;

namespace UI.Route.Routing;

public class RouteMessageRouter
{
    public async Task<WebMessageResult?> Handle(string route)
    {
        var registry = RouteCommandRegistry.Instance;
        
        var command = registry.Get(route ?? "");

        if (command == null)
            return null;

        var result = await command.Execute();
        
        return result;
    }
}