using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Storage.Repository;
using MyTagPocket.Storage.Upgrade.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Upgrade
{
  /// <summary>
  /// Upgrade settings storage
  /// </summary>
  public class UpgradeStorageSettings : IUpgradeStorageSettings
  {
    const string classCode = "[1000700]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    /// <summary>
    /// Check and if necessary upgrade storage
    /// </summary>
    public void CheckAndUpgrade()
    {
      const string methodCode = "[1000701]";
      try
      {
        UpgradeVesion();
      }
      catch (Exception ex)
      {
        Log.Fatal(ex, methodCode, "Check and Upgrade");
      }
    }

    /// <summary>
    /// Upgrade application version
    /// </summary>
    private void UpgradeVesion()
    {
      const string methodCode = "[1000702]";

      string pathFolder = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, null);
      if (!Directory.Exists(pathFolder))
      {
        Log.Trace(methodCode, $"Create folder {pathFolder}");
        Directory.CreateDirectory(pathFolder);
      }
      string pathVersion = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.Version).Name);
      if (File.Exists(pathVersion))
        return;

      var setRepo = new SettingsRepository();
      var verEntity = new Entities.Settings.Version();
      verEntity.Ver = "0";
      setRepo.AppVersionSave(verEntity);

    }
  }
}
