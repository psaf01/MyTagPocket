using System.Reflection;

namespace MyTagPocket.Repository.File.Entities.Settings
{
  /// <summary>
  /// Version application
  /// </summary>
  public class Version : FileEntityBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Version () : base(CoreUtil.DataTypeEnum.SETTINGS, "v", CoreUtil.EncryptTypeEnum.NONE)
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
