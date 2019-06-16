using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository;
using MyTagPocket.Resources;
using MyTagPocket.Storage.Interface.Upgrade;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Upgrade
{
  /// <summary>
  /// Upgrade contents storage
  /// </summary>
  public class UpgradeStorageContents : IUpgradeStorageBase
  {
    const string classCode = "[1002300]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    private IFileHelper _FileHelper;
    private ProcessStatusEnum _Status;
    private string _Result;
    private double _Progress;

    public UpgradeStorageContents()
    {
      _FileHelper = DependencyService.Get<IFileHelper>();
      _Status = ProcessStatusEnum.IDLE;
      _Result = string.Empty;
      _Progress = 0;
    }

    /// <summary>
    /// Code of process UpgradeStorageContents
    /// </summary>
    public string ProcessCode => "USC";

    /// <summary>
    /// Process Name
    /// </summary>
    public string ProcessName => ResourceApp.UpgradeStorageContentsLabel;

    /// <summary>
    /// Process description
    /// </summary>
    public string ProcessDescription => Resources.ResourceApp.UpgradeStorageContentsDescriptionLabel;

    /// <summary>
    /// If the process can start
    /// </summary>
    public bool CanRunProcess
    {
      get
      {
        if (_Status == ProcessStatusEnum.RUNNING || _Status == ProcessStatusEnum.PAUSED)
          return false;
        else
          return true;
      }
    }

    /// <summary>
    /// Result process
    /// </summary>
    public string ResultProcess
    {
      get => _Result;
      private set
      {
        _Result = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Status upgrade Storage Settings
    /// </summary>
    public ProcessStatusEnum StatusProcess
    {
      get => _Status;
      private set
      {
        _Status = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Progress
    /// 1 = 100%
    /// </summary>
    public double Progress
    {
      get => _Progress;
      private set
      {
        const string methodCode = "[1002301]";

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
    /// Property changed
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
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsActualVersion()
    {
      var setRepo = new FileRepository();

      var verEntity = new Entities.Settings.Version();
      setRepo.Load<Entities.Settings.Version>(verEntity);
      if (verEntity.Ver == verEntity.GetActuaAssemblylVersion())
        return true;

      return false;
    }

    /// <summary>
    /// Reinitialize contents
    /// </summary>
    public void ReInit()
    {
      const string methodCode = "[1002302]";
    }

    /// <summary>
    /// Run upgrade storage contenst
    /// </summary>
    public void Start()
    {
      Start(false);
    }

    /// <summary>
    /// Star upgrade contens
    /// </summary>
    public void Start(bool reinit = false)
    {
      const string methodCode = "[1002303]";
      if (!CanRunProcess)
      {
        Log.Trace(methodCode, "Cannot start upgrade storage contents.", new { statusProcess = StatusProcess.Name });
        return;
      }

      Log.Trace(methodCode, "Start upgrade storage contents");
      Progress = 0;
      StatusProcess = ProcessStatusEnum.RUNNING;

      try
      {

        Progress = 0.1;
        if (IsActualVersion() && reinit == false)
        {
          Progress = 1;
          StatusProcess = ProcessStatusEnum.IDLE;
          ResultProcess = ResourceApp.UpgradeStorageSettingsIsActual;
          return;
        }

        Progress = 0.5;
        
        Progress = 1;
        StatusProcess = ProcessStatusEnum.IDLE;
        ResultProcess = ResourceApp.UpgradeStorageSettingSucces;
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Unable to finish updating storage settings");
        StatusProcess = ProcessStatusEnum.ERROR;
        ResultProcess = ResourceApp.UpgradeStorageSettingsError;
      }
    }
  }
}
