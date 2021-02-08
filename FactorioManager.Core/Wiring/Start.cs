using System.IO.Abstractions;
using FactorioManager.Core.Infrastructure;
using FactorioManager.Core.Main.Data;
using Microsoft.Extensions.Logging;

namespace FactorioManager.Core.Wiring {
  /// <inheritdoc />
  public class Start : IStart {
    private readonly ILogger<Start> _logger;
    private readonly IFileSystem _fs;
    private readonly IUserConfigManager _userConfig;


    public Start(ILogger<Start> logger, IFileSystem fs, IUserConfigManager userConfig) {
      this._logger = logger;
      this._fs = fs;
      this._userConfig = userConfig;
    }


    /// <inheritdoc />
    public IStart InitBaseDir() {
      if (this._fs.Directory.Exists(Running.BaseDir)) return this;
      this._logger.LogInformation("User data directory not found, creating: {Dir}", Running.BaseDir);
      this._fs.Directory.CreateDirectory(Running.BaseDir);
      return this;
    }

    /// <inheritdoc />
    public IStart InitUserConfig() {
      this.InitBaseDir();
      if (this._userConfig.ConfigExists) return this;
      this._logger.LogInformation("User configuration not found, writing defaults.");
      this._userConfig.Save(new UserConfig());
      return this;
    }
  }
}