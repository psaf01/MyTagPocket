using MyTagPocket.Repository.Interfaces;
using Xamarin.Essentials;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// Application setting repository
  /// </summary>
  public class SettingRepository : ISettingRepository
  {
    /// <summary>
    /// Get persisted value from storage system
    /// </summary>
    /// <param name="key">Key persisted valud</param>
    /// <param name="defaultValue">Default value if Key not exists</param>
    /// <returns>Persisted value</returns>
    public string GetPersistText(string key, string defaultValue)
    {
      return Preferences.Get(key, defaultValue);
    }

    /// <summary>
    /// Set persist value to storage system
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    public void SetPersistText(string key, string value)
    {
      Preferences.Set(key, value);
    }
  }
}
