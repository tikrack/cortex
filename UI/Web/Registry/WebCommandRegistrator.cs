using UI.Web.Commands;

namespace UI.Web.Registry;

public class WebCommandRegistrator
{
    public void Register()
    {
        var registry = WebCommandRegistry.Instance;
        
        registry.Register(new RouteChangeCommand());
    }
}