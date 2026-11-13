using UI.Web.Contract;

namespace UI.Web.Registry;

public class CommandRegistry
{
    readonly Dictionary<string, IWebCommand> _commands = new();

    private static CommandRegistry? _instance = null;

    public static CommandRegistry Instance { 
        get
        {
            _instance ??= new CommandRegistry();

            return _instance;
        }
    }

    private CommandRegistry() {}

    public void Register(IWebCommand command)
    {
        _commands.Add(command.Name, command);
    }

    public IWebCommand? Get(string name)
    {
        IWebCommand? command;

        var status = _commands.TryGetValue(name, out command);

        if (status)
            return command;
        else
            throw new Exception($"Command {name} not found");
    }
}
