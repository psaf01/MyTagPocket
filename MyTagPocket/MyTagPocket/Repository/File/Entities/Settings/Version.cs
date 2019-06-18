using MyTagPocket.CoreUtil;
using System.Reflection;

namespace MyTagPocket.Repository.File.Entities.Settings
{
  /// <summary>
  /// Version application
  /// </summary>
  public class Version : VersionBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Version() : base(DataTypeEnum.SETTINGS, SystemEntityGuidConst.SettingsVersion)
    { }

    #region Public attributest
    /// <summary>
    /// Version
    /// </summary>
    public string Ver { get; set; }
    #endregion Public atributes

    #region Public method
    /// <summary>
    /// Actual version application asembly
    /// </summary>
    /// <returns></returns>
    public string GetActuaAssemblylVersion()
    {
      return $"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}";
    }
    #endregion Public method
  }
}
