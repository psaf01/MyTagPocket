using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Storage.Entities.Themes;
using MyTagPocket.Storage.Repository.Interface;
using System;
using System.IO;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Repository
{
  /// <summary>
  /// Theme application repository
  /// </summary>
  public class ThemeRepository : IThemeRepository
  {
    const string classCode = "[1001600]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Save theme
    /// </summary>
    /// <param name="theme">Theme</param>
    /// <returns>True - Save OK</returns>
    public bool Save(Theme theme)
    {
      const string methodCode = "[1001601]";
      try
      {
        Log.Trace(methodCode, $"Save theme [{theme.Name}]");
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(theme);
        string path = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.THEMES, theme.Name);
        File.WriteAllText(path, jsonString);
        return true;
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Save setting");
        return false;
      }
    }

    public bool Load(Theme theme)
    {
      const string methodCode = "[1001602]";
      Style textBlockStyle;
      try
      {
        textBlockStyle = (Style)Application.Current.Resources["TextBlockStyle"];
      }
      catch (Exception ex)
      {
        // exception handling
      }
      
      return true;
    }

   
  }
}
