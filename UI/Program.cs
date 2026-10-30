namespace UI;

using System.Diagnostics;
using System.Runtime.ExceptionServices;

class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Main());
    }
}