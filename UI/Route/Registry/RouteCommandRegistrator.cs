using UI.Route.Commands;

namespace UI.Route.Registry;

public class RouteCommandRegistrator
{
    public void Register()
    {
        var registry = RouteCommandRegistry.Instance;
        
        registry.Register(new SettingsRouteCommand());
    }
}