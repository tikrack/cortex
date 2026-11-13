using UI.Route.Contract;

namespace UI.Route.Registry;

public class RouteCommandRegistry
{
    readonly Dictionary<string, IRouteCommand> _commands = new();

    private static RouteCommandRegistry? _instance = null;

    public static RouteCommandRegistry Instance { 
        get
        {
            _instance ??= new RouteCommandRegistry();

            return _instance;
        }
    }

    private RouteCommandRegistry() {}

    public void Register(IRouteCommand command)
    {
        _commands.Add(command.Route, command);
    }

    public IRouteCommand? Get(string name)
    {
        IRouteCommand? command;

        var status = _commands.TryGetValue(name, out command);

        if (status)
            return command;

        return null;
    }
}