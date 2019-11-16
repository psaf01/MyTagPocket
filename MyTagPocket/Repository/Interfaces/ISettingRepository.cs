namespace MyTagPocket.Repository.Interfaces
{
  /// <summary>
  /// Interface application setting repository
  /// </summary>
  public interface ISettingRepository
  {
    /// <summary>
    /// Get persisted value from storage system
    /// </summary>
    /// <param name="key">Key persisted valud</param>
    /// <param name="defaultValue">Default value if Key not exists</param>
    /// <returns>Persisted value</returns>
    string GetPersistText(string key, string defaultValue);

    /// <summary>
    /// Set persist value to storage system
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    void SetPersistText(string key, string value);
  }
}
