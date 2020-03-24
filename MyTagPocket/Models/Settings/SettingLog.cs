using MyTagPocket.Repository.Interfaces;

namespace MyTagPocket.Models.Settings
{
  /// <summary>
  /// Setting for logging, auditing etc
  /// </summary>
  public class SettingLog
  {
    private ISettingRepository settingRepo;
    private string actualAuditCollection;
    private int maxAuditCollection;

    /// <summary>
    /// Constructor
    /// </summary>
    public SettingLog(ISettingRepository setttingRepository)
    {
      settingRepo = setttingRepository;
      actualAuditCollection = GetPersistText(nameof(ActualAuditCollection), actualAuditCollection);
      string maxAuditCollectionValue = GetPersistText(nameof(MaxAuditCollection), "5");
      int.TryParse(maxAuditCollectionValue, out maxAuditCollection);
      Init();
    }

    /// <summary>
    /// Initialize Current user
    /// </summary>
    public void Init()
    {
    }

    /// <summary>
    /// Max count audit collection in database
    /// </summary>
    public int MaxAuditCollection
    {
      get
      {
        return maxAuditCollection;
      }
      set
      {
        settingRepo.SetPersistText(nameof(MaxAuditCollection), value.ToString());
      }
    }
    /// <summary>
    /// Actual name audit collection in database
    /// </summary>
    public string ActualAuditCollection
    {
      get
      {
        return actualAuditCollection;
      }
      set
      {
        settingRepo.SetPersistText(nameof(ActualAuditCollection), value);
        actualAuditCollection = value;
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
      return settingRepo.GetPersistText($"{nameof(SettingLog)}{key}", defaultValue);
    }

    /// <summary>
    /// Set persist value
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    private void SetPersistText(string key, string value)
    {
      settingRepo.SetPersistText($"{nameof(SettingLog)}{key}", value);
    }
  }
}
