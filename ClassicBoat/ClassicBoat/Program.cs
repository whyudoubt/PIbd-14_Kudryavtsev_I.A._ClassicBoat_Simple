using System;
using System.Windows.Forms;

namespace ClassicBoat;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormBoat());
    }
}