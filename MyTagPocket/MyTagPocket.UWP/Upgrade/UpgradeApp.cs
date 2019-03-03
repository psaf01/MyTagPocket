using MyTagPocket.Storage.Upgrade;
using MyTagPocket.Storage.Upgrade.Interface;

namespace MyTagPocket.UWP.Upgrade
{
  public class UpgradeApp
  {
    const string classCode = "[2000300]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    public void CheckAndUpgradeStorage(IUpgradeStorageSettings upgradeStorageSettings, IUpgradeStorageContents upgradeStorageContents)
    {
      const string methodCode = "[2000301]";
      var upgradeStorage = new UpgradeStorage(upgradeStorageSettings, upgradeStorageContents);
      upgradeStorage.CheckAndUpgrade();
    }
  }
}
