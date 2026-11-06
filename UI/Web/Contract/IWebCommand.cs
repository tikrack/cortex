using System.Text.Json;

namespace UI.Web.Contract;

public interface IWebCommand
{
    string Name { get; }
    Action Execute(JsonElement data);
}
