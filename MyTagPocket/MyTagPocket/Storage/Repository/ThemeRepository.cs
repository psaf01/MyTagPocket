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
        FileTypeEnum fileType = FileTypeEnum.THEMES;
        theme.Description = Resources.ResourceApp.ThemeDescriptionExample;
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(theme);
        string folder = DependencyService.Get<IFileHelper>().GetLocalFolderPath(fileType);
        //check exist folder
        if (!Directory.Exists(folder))
        {
          Directory.CreateDirectory(folder);
        }

        string path = DependencyService.Get<IFileHelper>().GetLocalFilePath(fileType, theme.Name);
       
        File.WriteAllText(path, jsonString);
        Log.Trace(methodCode, "Saved file {file}", new { file= path});

        return true;
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Save theme");
        return false;
      }
    }

    public bool Load(Theme theme)
    {
      //Load default values
      theme = new Theme();
      return true;
    }

   
  }
}
