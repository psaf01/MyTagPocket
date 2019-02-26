using MyTagPocket.Storage.Upgrade.Interface;

namespace MyTagPocket.Storage.Upgrade
{
  /// <summary>
  /// Upgrade contents storage
  /// </summary>
  public class UpgradeStorageContents : IUpgradeStorageContents
  {
    public UpgradeStorageContents()
    {
    }

    public IUpgradeStorageContents ContextStorage { get; set; }

    public void CheckAndUpgrade()
    {
       
    }
  }
}
