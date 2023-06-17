using AutoGear.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoGear.HostBuilders;

public class ApplicationHostBuilder
{
    public static IHostBuilder CreateDefaultBuilder(string[] args)
        => Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection"), migration => migration.MigrationsAssembly("AutoGear"));
            });

            services.AddSingleton<MainWindow>();
        });
}
