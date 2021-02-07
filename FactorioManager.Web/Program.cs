using System;
using System.IO;
using FactorioManager.Core;
using FactorioManager.Core.Wiring;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FactorioManager.Web {
  public class Program {
    /// <summary>
    /// Main entry point.
    /// </summary>
    public static void Main() {
      Bootstrap();

      IHost host = Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(server => {
          server
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<ServerSetup>();
        })
        .Build();

      // Run startup initializations
      using (IServiceScope scope = host.Services.CreateScope()) {
        IServiceProvider services = scope.ServiceProvider;

        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("User dir: {Dir}", Running.BaseDir);

        services.GetRequiredService<IStart>()
          .InitBaseDir()
          .InitUserConfig();
      }

      // Run host
      host.Run();
    }

    /// <summary>
    /// Initialize the bare minimum that is required for the app to start up.
    /// </summary>
    public static void Bootstrap() {
      // BaseDir must be set as early as possible, since a lot of things rely on BasePath()
      String path = Running.InDebug
        ? new DirectoryInfo(AppContext.BaseDirectory).Parent!.Parent!.Parent!.Parent!.FullName
        : AppContext.BaseDirectory;
      Running.BaseDir = Path.Combine(path, "UserData");
    }
  }
}