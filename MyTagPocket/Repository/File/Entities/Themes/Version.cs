using MyTagPocket.CoreUtil;

namespace MyTagPocket.Repository.File.Entities.Themes
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
    public Version() : base(DataTypeEnum.Contents, SystemEntityGuidConst.ThemesVersion)
    { }

    #region Public attributest
    #endregion Public atributes

    #region Public method
   #endregion Public method
  }
}
