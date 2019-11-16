using MyTagPocket.Repository.Interfaces;
using System;
using Xamarin.Essentials;

namespace MyTagPocket.Models.Settings
{
  /// <summary>
  /// Current login user on device
  /// </summary>
  public class CurrentUser
  {
    private ISettingRepository settingRepo;

    /// <summary>
    /// Constructor
    /// </summary>
    public CurrentUser(ISettingRepository setttingRepository, string userDefaultFolderGuid)
    {
      settingRepo = setttingRepository;
      userFolderGuid = GetPersistText(nameof(UserFolderGuid), userDefaultFolderGuid);
      Init();
    }

    /// <summary>
    /// Initialize Current user
    /// </summary>
    public void Init()
    {
      userGuid = GetPersistText(nameof(UserGuid), Guid.NewGuid().ToString("N"));
    }

    private string userGuid;

    /// <summary>
    /// GUID current login user
    /// </summary>
    public string UserGuid 
    {
      get
      {
        return userGuid;
      }
      set
      {
        SetPersistText(nameof(UserGuid), value);
        userGuid = value;
      }
    }

    private string userFolderGuid;

    /// <summary>
    /// GUID current login user folder
    /// </summary>
    public string UserFolderGuid
    {
      get
      {
        return userFolderGuid;
      }
      set
      {
        SetPersistText(nameof(UserFolderGuid), value);
        userFolderGuid = value;
      }
    }

    /// <summary>
    /// Get persisted value
    /// </summary>
    /// <param name="key">Key persisted valud</param>
    /// <param name="defaultValue">Default value if Key not exists</param>
    /// <returns>Persisted value</returns>
    private string GetPersistText(string key, string defaultValue)
    {
      return settingRepo.GetPersistText($"{nameof(CurrentUser)}{key}", defaultValue);
    }

    /// <summary>
    /// Set persist value
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    private void SetPersistText(string key, string value)
    {
      settingRepo.SetPersistText($"{nameof(CurrentUser)}{key}", value);
    }
  }
}
