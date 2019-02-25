namespace MyTagPocket.Storage.Upgrade.Interface
{
  /// <summary>
  /// Interface upgrade storage
  /// </summary>
  public interface IUpgradeStorage : IUpgradeStorageBase
  {
    /// <summary>
    /// Context storage contents
    /// </summary>
    IUpgradeStorage ContextStorage { get; }
  }
}
