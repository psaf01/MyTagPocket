using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Resources;
using MyTagPocket.Storage.Interface.Upgrade;
using MyTagPocket.Storage.Repository;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTagPocket.Storage.Upgrade
{
  /// <summary>
  /// Upgrade settings storage
  /// </summary>
  public class UpgradeStorageSettings : IUpgradeStorageBase
  {
    const string classCode = "[1000700]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    private IFileHelper _FileHelper;
    private ProcessStatusEnum _Status;
    private string _Result;
    private double _Progress;

    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradeStorageSettings()
    {
      _FileHelper = DependencyService.Get<IFileHelper>();
      _Status = ProcessStatusEnum.IDLE;
      _Result = string.Empty;
      _Progress = 0;
    }

    /// <summary>
    /// Code of process UpgradeStorageSettings
    /// </summary>
    public string ProcessCode => "USS";

    /// <summary>
    /// Process Name
    /// </summary>
    public string ProcessName => ResourceApp.UpgradeStorageSettingsLabel;

    /// <summary>
    /// Process description
    /// </summary>
    public string ProcessDescription => Resources.ResourceApp.UpgradeStorageSettingsDescriptionLabel;

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
        const string methodCode = "[1000705]";

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
      var setRepo = new SettingsRepository();

      var verEntity = new Entities.Settings.Version();
      setRepo.Load(verEntity);
      if (verEntity.Ver == verEntity.GetActuaAssemblylVersion())
        return true;

      return false;
    }

    /// <summary>
    /// Reinit settings
    /// </summary>
    public void ReInit()
    {
      const string methodCode = "[1000704]";
      Log.Trace(methodCode, "Reinit settings");
      Start(true);
    }

    /// <summary>
    /// Run upgrade storage settings
    /// </summary>
    public void Start()
    {
      Start(false);
    }

    /// <summary>
    /// Run upgrade storage settings
    /// </summary>
    /// <param name="reinit">True = Reinitialize storage settings</param>
    public void Start(bool reinit = false)
    {
      const string methodCode = "[1000703]";

      if (!CanRunProcess)
      {
        Log.Trace(methodCode, "Cannot start upgrade storage settings.", new { statusProcess = StatusProcess.Name });
        return;
      }

      Log.Trace(methodCode, "Start upgrade storage settings");
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
        UpgradeVesion();
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

    /// <summary>
    /// Upgrade application version
    /// </summary>
    private void UpgradeVesion()
    {
      const string methodCode = "[1000702]";

      string pathFolder = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, null);
      if (!Directory.Exists(pathFolder))
      {
        Log.Trace(methodCode, $"Create folder {pathFolder}");
        try
        {
          Directory.CreateDirectory(pathFolder);
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, "Cant create folder", new { path = pathFolder });
        }
      }

      string pathVersion = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.Version).Name);

      var setRepo = new SettingsRepository();
      var verEntity = new Entities.Settings.Version();
      verEntity.Ver = verEntity.GetActuaAssemblylVersion();
      setRepo.Save(verEntity);
    }
  }
}
