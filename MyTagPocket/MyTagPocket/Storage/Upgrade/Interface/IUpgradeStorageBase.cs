namespace MyTagPocket.Storage.Upgrade.Interface
{
  /// <summary>
  /// Base interface upgrade storage
  /// </summary>
  public interface IUpgradeStorageBase
  {
    /// <summary>
    /// Check and if necessary upgrade storage
    /// </summary>
    void CheckAndUpgrade();
  }
}
