using System;

namespace FactorioManager.Core.Main.Data {
  /// <summary>
  /// All user configuration settings for the app.
  /// </summary>
  public class UserConfig : IEquatable<UserConfig> {
    /// <summary>
    /// Path where the user data for the game is located.
    /// https://wiki.factorio.com/Application_directory#User_data_directory
    /// </summary>
    /// <remarks>
    /// Windows: %appdata%\Factorio
    /// Mac: ~/Library/Application Support/factorio
    /// Linux: ~/.factorio
    /// </remarks>
    public String GameUserHome { get; }


    /// <summary>
    /// Constructor.
    /// </summary>
    public UserConfig(String gameUserHome = "") {
      this.GameUserHome = gameUserHome;
    }


    /// <inheritdoc />
    public override Boolean Equals(Object? obj) {
      return obj is UserConfig other && (
        other.GameUserHome == this.GameUserHome
      );
    }

    /// <inheritdoc />
    public override Int32 GetHashCode() {
      return this.GameUserHome.GetHashCode();
    }

    /// <inheritdoc />
    public Boolean Equals(UserConfig? other) {
      return other is { } o && o.GameUserHome == this.GameUserHome;
    }
    
    public static Boolean operator ==(UserConfig one, UserConfig other) => one.Equals(other);
    public static Boolean operator !=(UserConfig one, UserConfig other) => !(one == other);
  }
}