using MyTagPocket.Storage.Upgrade;

namespace MyTagPocket.CoreUtil.Upgrade
{
  /// <summary>
  /// Check and upgrade application
  /// </summary>
  public class UpgradeApp
  {
    const string classCode = "[1001300]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    /// <summary>
    /// Check version and upgrade storage
    /// </summary>
    public void CheckAndUpgradeStorage()
    {
      const string methodCode = "[1001301]";
      Log.Trace(methodCode, "Start Check and upgrade storage");
      var upgradeStorageContents = new UpgradeStorageContents();
      var upgradeStorageSettings = new UpgradeStorageSettings();
      var upgradeStorage = new UpgradeStorage(upgradeStorageSettings, upgradeStorageContents);
      upgradeStorage.CheckAndUpgrade();
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
