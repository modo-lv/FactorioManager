using System;
using System.IO.Abstractions;
using FactorioManager.Core.Data;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FactorioManager.Core.Infrastructure {
  /// <inheritdoc />
  public class UserConfigManager : IUserConfigManager {
    protected readonly String UserConfigFile;

    private readonly IFileSystem _fs;
    private readonly ILogger<UserConfigManager> _logger;

    public UserConfigManager(IFileSystem fs, ILogger<UserConfigManager> logger) {
      this._fs = fs;
      this._logger = logger;
      this.UserConfigFile = Running.BasePath("config.json");
    }


    /// <inheritdoc />
    public Boolean ConfigExists =>
      this._fs.File.Exists(this.UserConfigFile);

    /// <inheritdoc />
    public UserConfig Load() {
      String json = this._fs.File.ReadAllText(this.UserConfigFile);
      return JsonConvert.DeserializeObject<UserConfig>(json);
    }

    /// <inheritdoc />
    public void Save(UserConfig config) {
      // Serialize
      String json = JsonConvert.SerializeObject(config);
      // Ensure we don't write unreadable data
      var test = JsonConvert.DeserializeObject<UserConfig>(json);
      if (test != config) {
        throw new JsonSerializationException(
          "Serialized and deserialized configurations don't match, can't reliably save configuration.");
      }
      // Write
      this._fs.File.WriteAllText(this.UserConfigFile, json);
      this._logger.LogInformation("Saved configuration: {Cfg}", this.UserConfigFile);
    }

  }
}