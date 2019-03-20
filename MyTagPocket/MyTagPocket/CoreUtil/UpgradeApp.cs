using MyTagPocket.Storage.Upgrade;
using System.IO.Abstractions;

namespace MyTagPocket.CoreUtil.Upgrade
{
  /// <summary>
  /// Check and upgrade application
  /// </summary>
  public class UpgradeApp
  {
    const string classCode = "[1001300]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// File system
    /// </summary>
    private IFileSystem _FileSystem;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="storageFileSystem">File System</param>
    public UpgradeApp(IFileSystem fileSystem)
    {
      _FileSystem = fileSystem;
    }

    /// <summary>
    /// Check actual version application
    /// </summary>
    /// <returns>Tru = actual version</returns>
    public bool ActualVersionApp()
    {
      return false;
    }

    /// <summary>
    /// Check version and upgrade storage
    /// </summary>
    public void CheckAndUpgradeStorage()
    {
      const string methodCode = "[1001301]";
      Log.Trace(methodCode, "Start Check and upgrade storage");
      //var upgradeStorageContents = new UpgradeStorageContents(_FileSystem);
      //var upgradeStorageSettings = new UpgradeStorageSettings(_FileSystem);
      //var upgradeStorage = new UpgradeStorage(upgradeStorageSettings, upgradeStorageContents);
      //upgradeStorage.CheckAndUpgrade();
      Log.Trace(methodCode, "End Check and upgrade storage");
    }

    /// <summary>
    /// Check version and upgrade DAL
    /// </summary>
    public void CheckAndUpgradeDal()
    {
      const string methodCode = "[1001302]";
      Log.Trace(methodCode, "Start Check and upgrade database");

      Log.Trace(methodCode, "End Check and upgrade database");
    }
  }
}
