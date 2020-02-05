using MyTagPocket.Repository.Interfaces;
using System;
using Xamarin.Essentials;

namespace MyTagPocket.Models.Settings
{
  /// <summary>
  /// Current directory settings required to run the application
  /// </summary>
  public class CurrentFolders
  {
    private ISettingRepository settingRepo;

    /// <summary>
    /// Constructor
    /// </summary>
    public CurrentFolders(ISettingRepository setttingRepository)
    {
      settingRepo = setttingRepository;
      Init();
    }

    /// <summary>
    /// Initialize Current folders
    /// </summary>
    public void Init()
    {
      devicesGuid = GetPersistText(nameof(DevicesGuid), Guid.NewGuid().ToString("N"));
      usersGuid = GetPersistText(nameof(UsersGuid), Guid.NewGuid().ToString("N"));
      localRootFolder = GetPersistText(nameof(LocalRootFolder), string.Empty );
    }

    private string devicesGuid;

    /// <summary>
    /// GUID folder Devices
    /// </summary>
    public string DevicesGuid
    {
      get
      {
        return devicesGuid;
      }
      set
      {
        SetPersistText(nameof(DevicesGuid), value);
        devicesGuid = value;
      }
    }

    private string usersGuid;
    /// <summary>
    /// GUID folder Users
    /// </summary>
    public string UsersGuid
    {
      get
      {
        return usersGuid;
      }
      set
      {
        SetPersistText(nameof(UsersGuid), value);
        usersGuid = value;
      }
    }

    private string localRootFolder;

    /// <summary>
    /// Root path for local file data application
    /// </summary>
    public string LocalRootFolder
    {
      get
      {
        return localRootFolder;
      }
      set
      {
        SetPersistText(nameof(LocalRootFolder), value);
        localRootFolder = value;
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
      return settingRepo.GetPersistText($"{nameof(CurrentFolders)}{key}", defaultValue);
    }

    /// <summary>
    /// Set persist value
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    private void SetPersistText(string key, string value)
    {
      settingRepo.SetPersistText($"{nameof(CurrentFolders)}{key}", value);
    }
  }
}
