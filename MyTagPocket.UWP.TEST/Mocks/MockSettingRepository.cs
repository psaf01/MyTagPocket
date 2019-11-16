using MyTagPocket.Models.Settings;
using MyTagPocket.Repository.Interfaces;
using System.Collections.Generic;

namespace MyTagPocket.UWP.TEST.Mocks
{
  /// <summary>
  /// Mock setting repository
  /// </summary>
  public class MockSettingRepository : ISettingRepository
  {
    private Dictionary<string, string> persistText;

    public MockSettingRepository()
    {
      persistText = new Dictionary<string, string>();
    }
   
    /// <summary>
    /// Set mock basic test data
    /// </summary>
    /// <returns></returns>
    public void InitializeTestDataBasic()
    {
      Dictionary<string, string> test = new Dictionary<string, string>();
      
      CurrentFolders folder = new CurrentFolders(this);
      test.Add($"{nameof(CurrentFolders)}{nameof(folder.DevicesGuid)}", "9866738119bc461fb6c2bb14751ffcb0");
      test.Add($"{nameof(CurrentFolders)}{nameof(folder.UsersGuid)}", "f426ad8fd1f44849b61f9e3a486e4fab");

      CurrentDevice device = new CurrentDevice(this, test.GetValueOrDefault($"{ nameof(CurrentFolders)}{folder.DevicesGuid}"));
      test.Add($"{nameof(CurrentDevice)}{nameof(device.DeviceGuid)}", "675f383f708841568e27626889b0344d");

      CurrentUser user = new CurrentUser(this, test.GetValueOrDefault($"{ nameof(CurrentFolders)}{folder.UsersGuid}"));
      test.Add($"{nameof(CurrentUser)}{nameof(user.UserGuid)}", "2ec9e33c41094e8e9b75f7d5a77e7b57");
      persistText = test;
    }

    /// <summary>
    /// Get value
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="defaultValue">Default value</param>
    /// <returns>Value</returns>
    public string GetPersistText(string key, string defaultValue)
    {
      return persistText.GetValueOrDefault(key, defaultValue);
    }

    /// <summary>
    /// Set value
    /// </summary>
    /// <param name="key">key</param>
    /// <param name="value">value</param>
    public void SetPersistText(string key, string value)
    {
      persistText.Add(key, value);
    }

    /// <summary>
    /// Clear all persist values in mock
    /// </summary>
    public void ClearTestValues()
    {
      persistText.Clear();
    }
  }
}
