using FactorioManager.Core.Wiring;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorioManager.Web {
  public class ServerSetup {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {
      services
        // Web server
        .AddRouting()
        .AddLogging(_ => _
          .AddConsole()
          .AddDebug()
        )
        // Factorio manager
        .AddFactorioManagerCore()
        ;

      services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      app
        .UseStaticFiles()
        .UseRouting()
        .UseEndpoints(_ => _
          .MapRazorPages()
        );
    }
  }
}