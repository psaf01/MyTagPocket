namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Information about the application update progress
  /// </summary>
  public class UpgradeInfo
  {
    /// <summary>
    /// The upgrade Status
    /// </summary>
    public UpgradeStatusEnum Status { get; set; }
    /// <summary>
    /// The upgrade status info
    /// </summary>
    public string StatusInfo { get; set; }

    /// <summary>
    /// The name of the update item
    /// </summary>
    public string NameUpgradeItem { get; set; }

    /// <summary>
    /// Upgrade result text
    /// </summary>
    public string UpgradeResult { get; set; }
  }
}
