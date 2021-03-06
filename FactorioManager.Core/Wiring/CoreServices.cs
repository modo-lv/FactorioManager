﻿using System.IO.Abstractions;
using FactorioManager.Core.Infrastructure;
using FactorioManager.Core.Infrastructure.Notices;
using FactorioManager.Core.Main.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FactorioManager.Core.Wiring {
  public static class CoreServices {
    /// <summary>
    /// Add Factorio manager's core dependencies to the service collection.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns>Self for method chaining.</returns>
    public static IServiceCollection AddFactorioManagerCore(this IServiceCollection services) {
      services.AddSingleton<IStart, Start>();
      services.AddSingleton<IFileSystem, FileSystem>();
      services.AddSingleton<IUserConfigManager, UserConfigManager>();

      services.AddSingleton<INoticeBoard, NoticeBoard>();

      services.AddSingleton<IGameReader, GameReader>();

      // ReSharper disable once RedundantTypeArgumentsOfMethod
      services.AddScoped<UserConfig>(_ => _
        .GetRequiredService<IUserConfigManager>()
        .Load()
      );
      
      return services;
    }
  }
}