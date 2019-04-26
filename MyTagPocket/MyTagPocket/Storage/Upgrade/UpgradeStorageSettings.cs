using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Resources;
using MyTagPocket.Storage.Interface.Upgrade;
using MyTagPocket.Storage.Repository;
using System;
using System.IO;
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

    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradeStorageSettings()
    {
      _FileHelper = DependencyService.Get<IFileHelper>();
      //_Status = ProcessStatusEnum.Idle;
      _Result = string.Empty;
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
    public bool CanRunProcess => true; 

    /// <summary>
    /// Result process
    /// </summary>
    public string ResultProcess => _Result;

    public ProcessStatusEnum StatusProcess => _Status;

    public double Progress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsActualVersion()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Reinit settings
    /// </summary>
    public void ReInit()
    {
      const string methodCode = "[1000704]";
      /*
      try
      {
        if(_Status == ProcessStatusEnum.Runnig || _Status == ProcessStatusEnum.Paused)
        {
          Log.Trace(methodCode, $"Cannot start ReInit becouse is proces is {_Status.ToString()}");
        }
        Log.Trace(methodCode, "Reinit settings");
        UpgradeVesion();
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Unable to finish reinit storage settings");
      }
      */
    }

    /// <summary>
    /// Run upgrade storage settings
    /// </summary>
    public bool RunProcess()
    {
      const string methodCode = "[1000703]";
      try
      {
        UpgradeVesion();
        return true;
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Unable to finish updating storage settings");
        return false;
      }
    }

    public void Start()
    {
      throw new NotImplementedException();
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
        Directory.CreateDirectory(pathFolder);
      }
      string pathVersion = DependencyService.Get<IFileHelper>().GetLocalFilePath(FileTypeEnum.SETTINGS, typeof(Storage.Entities.Settings.Version).Name);
      if (File.Exists(pathVersion))
        return;

      var setRepo = new SettingsRepository();
      var verEntity = new Entities.Settings.Version();
      verEntity.Ver = "0";
      setRepo.Save(verEntity);

    }
  }
}
