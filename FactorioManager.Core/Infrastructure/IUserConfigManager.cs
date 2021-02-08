using System;
using FactorioManager.Core.Main.Data;

namespace FactorioManager.Core.Infrastructure {
  /// <summary>
  /// Read app user's configuration from the config file.
  /// </summary>
  public interface IUserConfigManager {
    /// <summary>
    /// Is user configuration is available for loading?
    /// </summary>
    Boolean ConfigExists { get; }

    /// <summary>
    /// Read and deserialize user configuration.
    /// </summary>
    /// <returns>Loaded user configuration.</returns>
    UserConfig Load();

    /// <summary>
    /// Serialize and write user configuration.
    /// </summary>
    /// <param name="config">User config to save.</param>
    void Save(UserConfig config);
  }
}