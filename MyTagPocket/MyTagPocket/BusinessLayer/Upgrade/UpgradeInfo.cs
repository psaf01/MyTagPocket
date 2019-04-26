using FFImageLoading.Forms;
using MyTagPocket.BusinessLayer.Interface.Upgrade;
using MyTagPocket.CoreUtil.Interface;
using System;
using System.ComponentModel;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Information about the application update progress
  /// </summary>
  public class UpgradeInfo : IUpgradeInfo
  {
    const string classCode = "[1002100]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    private IProcess _UpgradeItem;
    private string _UpgradeItemName;
    private string _UpgradeItemResult;
    private UpgradeStatusEnum _Status;

    public UpgradeInfo()
    { }
    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradeInfo(IProcess upgradeItem)
    {
      _Status = UpgradeStatusEnum.NotStart;
      _UpgradeItem = upgradeItem;
      _UpgradeItemName = upgradeItem.ProcessName;
    }

    /// <summary>
    /// The upgrade Status
    /// </summary>
    public UpgradeStatusEnum Status
    {
      get
      {
        return _Status;
      }
      set
      {
        _Status = value;
        OnPropertyChanged("Status");
      }
    }

    /// <summary>
    /// The upgrade status info
    /// </summary>
    public string StatusInfo { get; set; }

    
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

    /// <summary>
    /// The name of the update item
    /// </summary>
    public string UpgradeItemName
    {
      get
      {
        return _UpgradeItemName;
      }
      set
      {
        _UpgradeItemName = value;
        OnPropertyChanged("UpgradeItemName");
      }
    }

    /// <summary>
    /// Gets or sets the value of the process for the progres bar.
    /// </summary>
    public double Progress { get; set; }

    /// <summary>
    /// Upgrade result text
    /// </summary>
    public string UpgradeItemResult { get; set; }

    /// <summary>
    /// Upgrade modul item
    /// </summary>
    public IProcess UpgradeItem { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Property UpgradeInfo changed
    /// </summary>
    /// <param name="name">Property name</param>
    protected void OnPropertyChanged(string name)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
