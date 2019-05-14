using FFImageLoading.Forms;
using MyTagPocket.BusinessLayer.Upgrade;
using System.ComponentModel;

namespace MyTagPocket.BusinessLayer.Interface.Upgrade
{
  /// <summary>
  /// Interface Information about the application update progress
  /// </summary>
  public interface IUpgradeInfo : INotifyPropertyChanged
  {
    /// <summary>
    /// The upgrade Status
    /// </summary>
    UpgradeStatusEnum Status { get; }

    /// <summary>
    /// The upgrade status info
    /// </summary>
    string StatusInfo { get; set; }

    /// <summary>
    /// The name of the update item
    /// </summary>
    string UpgradeItemName { get; set; }

    /// <summary>
    /// Upgrade result text
    /// </summary>
    string UpgradeItemResult { get; set; }

    /// <summary>
    /// Upgrade item
    /// </summary>
    CoreUtil.Interface.IProcess UpgradeItem { get; set; }

    /// <summary>
    /// Icon 
    /// </summary>
    EmbeddedResourceImageSource Icon { get; }

    /// <summary>
    /// Gets or sets the value of the process for the progres bar.
    /// </summary>
    double Progress { get; }
  }
}