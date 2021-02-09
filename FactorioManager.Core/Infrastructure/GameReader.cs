using System;
using System.IO.Abstractions;
using System.Runtime.InteropServices;
using IniParser;
using IniParser.Model;
using Simpler.NetCore.Text;

namespace FactorioManager.Core.Infrastructure {
  public class GameReader : IGameReader {
    private readonly IFileSystem _fs;

    public GameReader(IFileSystem fs) {
      this._fs = fs;
    }

    public String? UserHome {
      get {
        String? path =
          this._combine(OSPlatform.Windows, Environment.SpecialFolder.ApplicationData, "Factorio") ??
          this._combine(OSPlatform.Linux, Environment.SpecialFolder.UserProfile, ".factorio") ??
          this._combine(OSPlatform.OSX, Environment.SpecialFolder.ApplicationData,
            "Library/Application Support/factorio");

        // ReSharper disable once InvertIf
        if (path is { } dir) {
          // Overrides
          String input = this._fs.Path.Combine(dir, "config", "config.ini");
          IniData config = new FileIniDataParser().ReadFile(input);
          String? po = config["path"]["write-data"];
          if (po != null && !po.Text().StartsWith("__PATH__")) {
            path = po;
          }
        }

        return path;
      }
    }


    private String? _combine(OSPlatform platform, Environment.SpecialFolder home, String folder) =>
      RuntimeInformation.IsOSPlatform(platform)
        ? this._fs.Path.Combine(Environment.GetFolderPath(home), folder)
        : null;
  }
}