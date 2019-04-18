using FFImageLoading.Forms;
using System;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Information about the application update progress
  /// </summary>
  public class UpgradeInfo
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradeInfo()
    {
      Status = UpgradeStatusEnum.NotStart;
    }

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
    
    /// <summary>
    /// Icon 
    /// </summary>
    public EmbeddedResourceImageSource Icon
    {
      get
      {
        return new EmbeddedResourceImageSource(new Uri("resource://MyTagPocket.Resources.Images.spinner.svg"));
      }
    }
  }
}
