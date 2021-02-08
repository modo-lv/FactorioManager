namespace FactorioManager.Core.Infrastructure.Notices {
  /// <summary>
  /// Notice kind determines how its displayed to the user. 
  /// </summary>
  public enum NoticeKind {
    /// <summary>
    /// Informative notice.
    /// </summary>
    Information,
    /// <summary>
    /// Notice that an action/process has completed successfully.
    /// </summary>
    Success,
    /// <summary>
    /// Warning that something isn't quite right.
    /// </summary>
    Warning,
    /// <summary>
    /// Something has failed or is otherwise wrong. 
    /// </summary>
    Error,
  }
}