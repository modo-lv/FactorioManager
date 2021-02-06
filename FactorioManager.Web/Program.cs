using System;
using System.IO;
using FactorioManager.Core.Wiring;
using FactorioManager.Web.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FactorioManager.Web {
  public class Program {
    public static void Main(String[] args) {
      Bootstrap();

      IWebHost host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup<ServerSetup>()
        .Build();

      // Run startup initializations
      using (IServiceScope scope = host.Services.CreateScope()) {
        IServiceProvider services = scope.ServiceProvider;

        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("User dir: {Dir}", Running.BaseDir);

        services.GetRequiredService<IStart>()
          .InitBaseDir();
      }

      // Run host
      host.Run();
    }

    public static void Bootstrap() {
      // BaseDir must be set as early as possible, since a lot of things rely on BasePath()
      Running.BaseDir = Path.Combine(Running.InDebug
          ? new DirectoryInfo(AppContext.BaseDirectory).Parent!.Parent!.Parent!.Parent!.FullName
          : AppContext.BaseDirectory, "UserData"
      );
    }
  }
}