using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Storage.Repository;
using MyTagPocket.Storage.Upgrade.Interface;
using System;
using System.IO;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Upgrade
{
  /// <summary>
  /// Upgrade storage
  /// </summary>
  public class UpgradeStorage : IUpgradeStorageBase
  {
    const string classCode = "[1000100]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);
    #region Public method
    
    /// <summary>
    /// Check and if necessary upgrade storage
    /// </summary>
    public void CheckAndUpgrade()
    {
      const string methodCode = "[1000101]";
      try
      {
        Log.Trace(methodCode, "Start Check And Upgrade application storage");
        string path = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.AppGlobal).Name);
        if(CheckActualVersion())
        {
          Log.Trace(methodCode, "End check. Storage actual");
          return;
        }
        new UpgradeStorageSettings().CheckAndUpgrade();
        new UpgradeStorageContents().CheckAndUpgrade();
        var repoSett = new SettingsRepository();
        //write actual version application if finished upgrade OK
        var ver = new Entities.Settings.Version();
        repoSett.Load(ver);
        ver.Ver = ver.GetActuaAssemblylVersion();
        repoSett.Save(ver); 
        Log.Trace(methodCode, "End Check And Upgrade application storage");
      }
      catch(Exception ex)
      {
        Log.Fatal(ex, methodCode, "Check and Upgrade");
        throw ex;
      }
    }
    #endregion Public method

    #region Public Properties

    #endregion Public Properties

    #region Private method
    /// <summary>
    /// Check actual version
    /// </summary>
    /// <returns></returns>
    private bool CheckActualVersion()
    {
      const string methodCode = "[1000102]";
      Log.Trace(methodCode, "Check actual version storage");
      string pathFolder = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, null);
      if (!Directory.Exists(pathFolder))
      {
        return false;
      }

      string pathVersion = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.Version).Name);
      if (File.Exists(pathVersion))
      {
        var setRepo = new SettingsRepository();
        var ver = new Entities.Settings.Version();
        setRepo.Load(ver);
        if (ver == null)
          return false;

        var verEntity = new Entities.Settings.Version();
        if(ver.Ver == verEntity.GetActuaAssemblylVersion())
          return true;
      }
      return false;
    }
    #endregion Private method
  }
}