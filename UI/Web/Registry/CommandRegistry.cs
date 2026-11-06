using UI.Web.Contract;

namespace UI.Web.Registry;

public class CommandRegistry
{
    Dictionary<string, IWebCommand> _commands = new();

    private static CommandRegistry? _instance = null;

    public static CommandRegistry Instance { 
        get
        {
            if(_instance == null)
            {
                _instance = new CommandRegistry();
            }

            return _instance;
        }
    }

    private CommandRegistry() {}

    public void Register(IWebCommand command)
    {
        _commands.Add(command.Name, command);
    }

    public IWebCommand Get(string name)
    {
        return _commands[name];
    }
}
