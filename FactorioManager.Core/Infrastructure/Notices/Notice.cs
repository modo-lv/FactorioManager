using System;

namespace FactorioManager.Core.Infrastructure.Notices {
  /// <summary>
  /// An announcement message that needs to be shown to the user.
  /// </summary>
  public class Notice {
    /// <summary>
    /// Text to display, markdown supported.
    /// </summary>
    public String Message;

    /// <inheritdoc cref="NoticeKind"/>
    public NoticeKind Kind;

    /// <summary>
    /// An optional unique name for the message. Messages with unique names remain visible until manually hidden by the
    /// user or explicitly removed by the app.
    /// </summary>
    public readonly String Name;


    public Notice(String message = "", NoticeKind kind = NoticeKind.Information, String name = "") {
      this.Message = message;
      this.Kind = kind;
      this.Name = name;
    }
  }
}