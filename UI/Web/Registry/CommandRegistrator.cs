using UI.Web.Commands;

namespace UI.Web.Registry;

public class CommandRegistrator
{
    public void Register()
    {
        var registry = CommandRegistry.Instance;
        
        registry.Register(new RouteChangeCommand());
    }
}