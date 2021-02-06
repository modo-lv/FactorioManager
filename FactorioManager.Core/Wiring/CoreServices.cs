using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FactorioManager.Core.Wiring {
  public static class CoreServices {
    public static void AddTo(IServiceCollection services) {
      services.AddSingleton<IStart, Start>();
      services.AddSingleton<IFileSystem, FileSystem>();
    }
  }
}