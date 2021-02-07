namespace FactorioManager.Core.Wiring {
  public interface IStart {
    /// <summary>
    /// Make sure <see cref="Running.BaseDir"/> exists and is accessible.
    /// </summary>
    /// <returns>Self for method chaining.</returns>
    IStart InitBaseDir();

    /// <summary>
    /// Ensure that a user configuration storage exists for successful reading (even if empty). 
    /// </summary>
    /// <remarks>
    /// Calls <see cref="InitBaseDir"/> in order to ensure the config file can be created.
    /// </remarks>
    /// <returns>Self for method chaining.</returns>
    IStart InitUserConfig();
  }
}