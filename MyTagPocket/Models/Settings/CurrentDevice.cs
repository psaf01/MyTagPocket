using MyTagPocket.Repository.Interfaces;
using System;

namespace MyTagPocket.Models.Settings
{
  /// <summary>
  /// Currently used device
  /// </summary>
  public class CurrentDevice
  {
    /// <summary>
    /// Setting repository
    /// </summary>
    private ISettingRepository settingRepo;

    /// <summary>
    /// Constructor
    /// </summary>
    public CurrentDevice(ISettingRepository setttingRepository, string currentFolderGuid)
    {
      settingRepo = setttingRepository;
      deviceFolderGuid = GetPersistText(nameof(DeviceFolderGuid), currentFolderGuid);
      Init();
    }

    /// <summary>
    /// Initialize Current device
    /// </summary>
    public void Init()
    {
      deviceGuid = GetPersistText(nameof(DeviceGuid), Guid.NewGuid().ToString("N"));
    }

    private string deviceGuid;

    /// <summary>
    /// GUID current use device
    /// </summary>
    public string DeviceGuid
    {
      get
      {
        return deviceGuid;
      }
      set
      {
        settingRepo.SetPersistText(nameof(DeviceGuid), value);
        deviceGuid = value;
      }
    }

    private string deviceFolderGuid;

    /// <summary>
    /// GUID Current directory where device information is stored 
    /// </summary>
    public string DeviceFolderGuid
    {
      get
      {
        return deviceFolderGuid;
      }
      set
      {
        SetPersistText(nameof(DeviceFolderGuid), value);
        deviceFolderGuid = value;
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
      return settingRepo.GetPersistText($"{nameof(CurrentDevice)}{key}", defaultValue);
    }

    /// <summary>
    /// Set persist value
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    private void SetPersistText(string key, string value)
    {
      settingRepo.SetPersistText($"{nameof(CurrentDevice)}{key}", value);
    }
  }
}
