using MyTagPocket.Repository.File.Entities;
using Newtonsoft.Json;

namespace MyTagPocket.Repository.File.Entities.Themes
{
  /// <summary>
  /// Definition theme for GUI
  /// </summary>
  public class Theme : FileEntityBase<Theme>
  {
    public Theme(string entityId) : base(CoreUtil.DataTypeEnum.THEMES, entityId, CoreUtil.EncryptTypeEnum.NONE)
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
    /// Version theme
    /// </summary>
    public string Version { get; set; } = "1";

    /// <summary>
    /// Version theme, number. If failed during transfer from string will be version 1.
    /// </summary>
    [JsonIgnore]
    public int VersionInt
    {
      get
      {
        int version = int.TryParse(Version, out version) ? version : 1;
        return version;
      }
    }

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
