using MyTagPocket.CoreUtil;

namespace MyTagPocket.Repository.Files.Entities.Themes
{
  /// <summary>
  /// Basic properties theme settings 
  /// </summary>
  public class ThemeBasicSettings : FileEntityBase<ThemeBasicSettings>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public ThemeBasicSettings() : base(CoreUtil.DataTypeEnum.Setting, SystemEntityGuidConst.ThemeBasicSettings, EncryptTypeEnum.None, 1)
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
