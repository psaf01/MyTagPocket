using MyTagPocket.Storage.Entities.Settings;

namespace MyTagPocket.Storage.Repository.Interface
{
  /// <summary>
  /// Interface settings repository
  /// </summary>
  public interface ISettingsRespository
  {
    /// <summary>
    /// Save application global settings
    /// </summary>
    /// <param name="appGlobal">Application global settings</param>
    void Save(AppGlobal appGlobal);

    /// <summary>
    /// Load  application version
    /// </summary>
    /// <returns>Application version</returns>
    void Load(Entities.Settings.Version version);

    /// <summary>
    /// Save application version
    /// </summary>
    /// <param name="Version">Application version</param>
    void Save(Entities.Settings.Version version);
  }
}
