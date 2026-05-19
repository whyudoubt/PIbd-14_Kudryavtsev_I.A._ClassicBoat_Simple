using System;
using System.Windows.Forms;
using Serilog;

namespace ClassicBoat;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Настройка Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs/boatlog-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

        try
        {
            Log.Information("Приложение запущено");
            ApplicationConfiguration.Initialize();
            Application.Run(new FormCompany());
            Log.Information("Приложение завершено");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Критическая ошибка при запуске приложения");
            MessageBox.Show($"Критическая ошибка: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}