using System;
using System.IO;

namespace FactorioManager.Core {
  /// <summary>
  /// Globally available runtime information.
  /// </summary>
  public class Running {
    /// <summary>
    /// Root folder where user content (configuration, exports etc.) is stored.
    /// </summary>
    public static String BaseDir = "";

    /// <summary>
    /// Get full path to a given file/folder in the app's base directory.
    /// </summary>
    public static String BasePath(String path) => Path.Combine(BaseDir, path);

    /// <summary>
    /// Are we running a debug version of the app?
    /// </summary>
    public static Boolean InDebug =
#if DEBUG
      true;
#else
			false;
#endif

    /// <summary>
    /// Is the app being run in an integration test?
    /// </summary>
    public static Boolean InTest = false;
  }
}