namespace Business.Attributes;

public class EnumInfoAttribute : Attribute
{
    public string Title { get; private set; }

    public EnumInfoAttribute(string title)
    {
        Title = title;
    }
}
