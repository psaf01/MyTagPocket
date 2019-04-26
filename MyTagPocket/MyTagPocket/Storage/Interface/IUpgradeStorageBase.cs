using MyTagPocket.CoreUtil.Interface;

namespace MyTagPocket.Storage.Interface.Upgrade
{
  /// <summary>
  /// Base interface upgrade storage
  /// </summary>
  public interface IUpgradeStorageBase: IProcess
  {
    /// <summary>
    /// Check actual version
    /// </summary>
    /// <returns>True = actual version</returns>
    bool IsActualVersion();

    /// <summary>
    /// Reinitialize storage modul
    /// </summary>
    void ReInit();
  }
}
