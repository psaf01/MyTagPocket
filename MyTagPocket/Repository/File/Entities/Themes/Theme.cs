using MyTagPocket.Repository.File.Entities;
using Newtonsoft.Json;

namespace MyTagPocket.Repository.File.Entities.Themes
{
  /// <summary>
  /// Definition theme for GUI
  /// </summary>
  public class Theme : FileEntityBase<Theme>
  {
    public Theme(string entityId) : base(CoreUtil.DataTypeEnum.Theme, entityId, CoreUtil.EncryptTypeEnum.None, 1)
    {
      BasicSetting = new ThemeBasicSettings();
    }

    /// <summary>
    /// Name theme
    /// </summary>
    public string Name { get; set; } = "MyTagPocket";

    /// <summary>
    /// File name theme in storage
    /// </summary>
    public string FileNameTeheme { get; set; } = "MyTagPocket";

    /// <summary>
    /// Description theme
    /// </summary>
    public string Description { get; set; } = Resources.ResourceApp.ThemeDescription;

    /// <summary>
    /// Group Basic settings
    /// </summary>
    public ThemeBasicSettings BasicSetting { get; set; }
  }
}
