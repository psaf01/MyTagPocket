using MyTagPocket.CoreUtil;

namespace MyTagPocket.Repository.File.Entities.Themes
{
  /// <summary>
  /// Version application
  /// </summary>
  public class Version : VersionBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Version() : base(DataTypeEnum.CONTENTS, SystemEntityGuidConst.ThemesVersion)
    { }

    #region Public attributest
    /// <summary>
    /// Version
    /// </summary>
    public string Ver { get; set; }
    #endregion Public atributes

    #region Public method
   #endregion Public method
  }
}
