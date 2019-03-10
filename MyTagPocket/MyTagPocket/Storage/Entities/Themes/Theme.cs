using Newtonsoft.Json;
using System.Text;

namespace MyTagPocket.Storage.Entities.Themes
{
  /// <summary>
  /// Definition theme for GUI
  /// </summary>
  public class Theme
  {
    public Theme()
    {
      BasicSetting = new BasicSettings();
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
        int version = int.TryParse(Version, out  version) ? version : 1;
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
    public BasicSettings BasicSetting { get; set; } 
  }
}
