using AutoGear.Domain;
using AutoGear.HostBuilders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Windows;

namespace AutoGear;

public partial class App : Application
{
    public IHost ApplicationHost { get; private set; }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ApplicationHost = ApplicationHostBuilder.CreateDefaultBuilder(e.Args).Build();

        var mainWindow = ApplicationHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        await ApplicationHost.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        await ApplicationHost.StopAsync();
        ApplicationHost.Dispose();
    }
}
