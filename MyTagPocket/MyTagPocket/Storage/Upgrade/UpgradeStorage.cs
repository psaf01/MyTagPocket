using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Storage.Upgrade.Interface;
using System;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Upgrade
{
  /// <summary>
  /// Upgrade storage
  /// </summary>
  public class UpgradeStorage : IUpgradeStorage
  {
    const string classCode = "[1000100]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);
    private IUpgradeStorageContents _UpgradeStorageContents;
    #region Public method
    
    /// <summary>
    /// Construktor
    /// </summary>
    /// <param name="upgradeStorageContents">Upgrade contents storage</param>
    public UpgradeStorage(IUpgradeStorageContents upgradeStorageContents)
    {
      _UpgradeStorageContents = upgradeStorageContents;
    }

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

        //_UpgradeStorageContents.CheckAndUpgrade();
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
    /// <summary>
    /// Context storage contents
    /// </summary>
    public IUpgradeStorage ContextStorage
    {
      get
      {
        return this;
      }
    }
    #endregion Public Properties
  }
}