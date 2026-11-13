using UI.Web.Contract;

namespace UI.Web.Registry;

public class WebCommandRegistry
{
    readonly Dictionary<string, object> _commands = new();

    private static WebCommandRegistry? _instance = null;

    public static WebCommandRegistry Instance { 
        get
        {
            _instance ??= new WebCommandRegistry();

            return _instance;
        }
    }

    private WebCommandRegistry() {}

    public void Register(IWebCommand command)
    {
        _commands.Add(command.Name, command);
    }


    public void Register(IAsyncWebCommand command)
    {
        _commands.Add(command.Name, command);
    }

    public object? Get(string name)
    {
        if (_commands.TryGetValue(name, out var command))
            return command;

        throw new Exception($"Command {name} not found");
    }
}
