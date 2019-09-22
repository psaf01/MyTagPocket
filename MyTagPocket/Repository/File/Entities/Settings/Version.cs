using MyTagPocket.CoreUtil;
using System.Reflection;

namespace MyTagPocket.Repository.File.Entities.Settings
{
  /// <summary>
  /// Version application
  /// </summary>
  [FileVersion(1)]
  public class Version : VersionBase<Version>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Version() : base(DataTypeEnum.Settings, SystemEntityGuidConst.SettingsVersion)
    { }

    #region Public attributest
    #endregion Public atributes

    #region Public method
    #endregion Public method
  }
}
