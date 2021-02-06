using System.IO.Abstractions;
using FactorioManager.Web.Core;
using Microsoft.Extensions.Logging;

namespace FactorioManager.Core.Wiring {
  public class Start : IStart {
    private readonly ILogger<Start> _logger;
    private readonly IFileSystem _fs;

    public Start(ILogger<Start> logger, IFileSystem fs) {
      this._logger = logger;
      this._fs = fs;
    }


    /// <summary>
    /// Make sure <see cref="Running.BaseDir"/> exists and is accessible.
    /// </summary>
    public void InitBaseDir() {
      if (this._fs.Directory.Exists(Running.BaseDir)) return;
      this._fs.Directory.CreateDirectory(Running.BaseDir);
      this._logger.LogInformation("Created: {Dir}", Running.BaseDir);
    }
  }
}