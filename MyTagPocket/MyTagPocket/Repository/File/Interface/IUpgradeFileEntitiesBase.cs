using MyTagPocket.CoreUtil.Interface;

namespace MyTagPocket.Storage.Interface.Upgrade
{
  /// <summary>
  /// Base interface upgrade file storage
  /// </summary>
  public interface IUpgradeFileEntitiesBase: IProcess
  {
    /// <summary>
    /// Check actual version
    /// </summary>
    /// <returns>True = actual version</returns>
    bool IsActual();

    /// <summary>
    /// Reinitialize storage modul
    /// </summary>
    void ReInit();
  }
}
