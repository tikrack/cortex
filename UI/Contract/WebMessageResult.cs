namespace UI.Web.Contract;

public class WebMessageResult
{
    public bool IsSuccess { get; set; } = true;
    
    public string Type { get; set; } = string.Empty;
    
    public string Message { get; set; } = string.Empty;
    public object Data { get; set; } = new ();

    public List<string> Errors = [];
}