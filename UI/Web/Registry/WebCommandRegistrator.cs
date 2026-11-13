using UI.Web.Commands.Settings;

namespace UI.Web.Registry;

public class WebCommandRegistrator
{
    public void Register()
    {
        var registry = WebCommandRegistry.Instance;
        
        registry.Register(new AllSettingsCommand());
        registry.Register(new UpdateSettingValueCommand());
    }
}