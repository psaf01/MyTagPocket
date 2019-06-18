using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Entities;

namespace MyTagPocket.Repository.File.Entities.Themes
{
  /// <summary>
  /// Basic properties theme settings 
  /// </summary>
  public class ThemeBasicSettings : FileEntityBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public ThemeBasicSettings() : base(CoreUtil.DataTypeEnum.SETTINGS, SystemEntityGuidConst.ThemeBasicSettings, EncryptTypeEnum.NONE)
    { }

    /// <summary>
    /// Default baground page color
    /// </summary>
    public string DefaultBackgroundPageColor { get; set; } = "#336699";

    /// <summary>
    /// Default error label text color
    /// </summary>
    public string ErrorLabelColor { get; set; } = "#A54440";
  }
}
