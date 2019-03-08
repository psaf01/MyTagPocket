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
    public string Name { get; set; }

    /// <summary>
    /// File name theme in storage
    /// </summary>
    public string FileNameTeheme { get; set; }

    /// <summary>
    /// Version theme
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// Version theme, number. If failed during transfer from string will be version 1.
    /// </summary>
    [JsonIgnore]
    public int VersionInt
    {
      get
      {
        int version = 1;
        int.TryParse(Version, out version);
        return version;
      }
    }

    /// <summary>
    /// Description theme
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Group Basic settings
    /// </summary>
    public BasicSettings BasicSetting { get; set; } 
  }
}
