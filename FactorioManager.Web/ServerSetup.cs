using FactorioManager.Core.Wiring;
using FactorioManager.Web.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FactorioManager.Web {
  public class ServerSetup {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {
      CoreServices.AddTo(services);

      // Logging
      services.AddLogging(builder => {
        builder
          .AddFilter("FactorioManager.Web", Running.InDebug ? LogLevel.Debug : LogLevel.Information)
          .AddFilter("Microsoft", LogLevel.Warning)
          .AddFilter("System", LogLevel.Warning)
          .AddConsole()
          .AddDebug();
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      app.UseStaticFiles();
    }
  }
}