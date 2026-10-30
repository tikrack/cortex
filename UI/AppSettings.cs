namespace UI;

public static class AppSettings
{
    public static int DevelopmentPort = 5173;

    public static bool IsDevelopment
    {
        get
        {
    #if DEBUG
                return true;
    #else
                return false;
    #endif
        }
    }
}
