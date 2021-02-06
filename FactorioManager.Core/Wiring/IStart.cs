using FactorioManager.Web.Core;

namespace FactorioManager.Core.Wiring {
  public interface IStart {
    /// <summary>
    /// Make sure <see cref="Running.BaseDir"/> exists and is accessible.
    /// </summary>
    void InitBaseDir();
  }
}