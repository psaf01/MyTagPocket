namespace MyTagPocket.Storage.Upgrade.Interface
{
  /// <summary>
  /// Upgrade contents storage
  /// </summary>
  public interface IUpgradeStorageContents : IUpgradeStorageBase
  {
    /// <summary>
    /// Context contents storage
    /// </summary>
    IUpgradeStorageContents ContextStorage { get; }
  }
}
