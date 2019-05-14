using FFImageLoading.Forms;
using MyTagPocket.BusinessLayer.Interface.Upgrade;
using MyTagPocket.CoreUtil.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
    private double _Progress;
    private string _StatusInfo;

    public UpgradeInfo()
    { }
    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradeInfo(IProcess upgradeItem)
    {
      _Status = UpgradeStatusEnum.NOTSTART;
      _UpgradeItem = upgradeItem;
      _UpgradeItemName = upgradeItem.ProcessName;
      _Progress = 0;
      _StatusInfo = Resources.ResourceApp.UpgradeInfoNotStarted;
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
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The upgrade status info
    /// </summary>
    public string StatusInfo
    {
      get => _StatusInfo;
      set
      {
        _StatusInfo = value;
        OnPropertyChanged();
      }
    }


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
    public double Progress
    {
      get => _Progress;
      set
      {
        const string methodCode = "[1002101]";
        if (value < 0 || value > 1)
        {
          Log.Error(methodCode, $"The value [{value}] is out of range");
          return;
        }
        _Progress = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Upgrade result text
    /// </summary>
    public string UpgradeItemResult
    {
      get => _UpgradeItemResult;
      set
      {
        _UpgradeItemResult = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Upgrade modul item
    /// </summary>
    public IProcess UpgradeItem
    {
      get => _UpgradeItem;
      set
      {
        if (_UpgradeItem != null)
        {
          //_UpgradeItem.PropertyChanged -= PropertyChangedEventHandler();
        }
        _UpgradeItem = value;
        _UpgradeItem.PropertyChanged += new PropertyChangedEventHandler(UpgradeInfoItemPropertyChanged);

      }
    }
    /// <summary>
    /// Event handler for change Property UpgradeInfo
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    ///<summary>
    /// This method is called by the Set accessor of each property.  
    /// The CallerMemberName attribute that is applied to the optional propertyName  
    /// parameter causes the property name of the caller to be substituted as an argument.  
    /// </summary>
    private void OnPropertyChanged([CallerMemberName] String propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Change process item
    /// </summary>
    /// <param name="sender">Process</param>
    /// <param name="e">Process property</param>
    private void UpgradeInfoItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      const string methodCode = "[1002102]";

      Progress = _UpgradeItem.Progress;
      if (e.PropertyName == _UpgradeItem.StatusProcess.ToString())
      {
        switch (_UpgradeItem.StatusProcess.Value)
        {
          case CoreUtil.ProcessStatusEnum.ProcessStatus.Runnig:
            Status = UpgradeStatusEnum.PROGRESS;
            StatusInfo = Resources.ResourceApp.UpgradeInfoStarted;
            break;
          case CoreUtil.ProcessStatusEnum.ProcessStatus.Error:
            Status = UpgradeStatusEnum.ENDERROR;
            StatusInfo = Resources.ResourceApp.UpgradeStatusEndError;
            break;
          case CoreUtil.ProcessStatusEnum.ProcessStatus.Idle:
            Status = UpgradeStatusEnum.ENDSUCCESS;
            StatusInfo = Resources.ResourceApp.UpgradeStatusEndSucces;
            break;
          case CoreUtil.ProcessStatusEnum.ProcessStatus.Paused:
            Status = Status = UpgradeStatusEnum.STOP;
            StatusInfo = Resources.ResourceApp.UpgradeInfoNotStarted;
            break;
          default:
            Log.Error(methodCode, $"The value [{_UpgradeItem.StatusProcess.Name}] is out of range");
            break;
        }
      }
    }
  }
}
