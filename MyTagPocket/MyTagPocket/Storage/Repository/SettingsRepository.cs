using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Storage.Entities.Settings;
using MyTagPocket.Storage.Repository.Interface;
using System;
using System.IO;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Repository
{
  public class SettingsRepository : ISettingsRespository
  {
    const string classCode = "[1000600]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Save application global settings
    /// </summary>
    /// <param name="appGlobal">Application global settings</param>
    public void Save(AppGlobal appGlobal)
    {
      const string methodCode = "[1000601]";
      try
      {
        Log.Trace(methodCode, "Save settings application");
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(appGlobal);
        string path = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.AppGlobal).Name);
        File.WriteAllText(path, jsonString);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Save setting");
      }
    }

    /// <summary>
    /// Load  application version
    /// </summary>
    /// <returns>Application version</returns>
    public void Load(Entities.Settings.Version version)
    {
      const string methodCode = "[1000602]";
      try
      {
        Log.Trace(methodCode, "Edit version application");
        string path = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.Version).Name);
        string jsonString = File.ReadAllText(path);
        version = Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.Settings.Version>(jsonString);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Load version application");
        version = null;
      }
    }
    /// <summary>
    /// Save application version
    /// </summary>
    /// <param name="Version">Application version</param>
    public void Save(Entities.Settings.Version version)
    {
      const string methodCode = "[1000602]";
      try
      {
        Log.Trace(methodCode, "Save version application");
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(version);
        string path = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.Version).Name);
        File.WriteAllText(path, jsonString);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Save version application");
      }
    }

  }
}
