using System.Collections.ObjectModel;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Upgrade category
  /// </summary>
  public class UpgradeInfoList : ObservableCollection<UpgradeInfo>
  {
    const string classCode = "[1002200]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Category name
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Upgrade item
    /// </summary>
    public ObservableCollection<UpgradeInfo> UpgradeItem => this;

    /// <summary>
    /// Start upgrade all items in Category list
    /// </summary>
    public void Start()
    {
      foreach (var item in UpgradeItem)
      {
        if (item.UpgradeItem.CanRunProcess)
          item.UpgradeItem.Start();
      }
    }
  }
}
