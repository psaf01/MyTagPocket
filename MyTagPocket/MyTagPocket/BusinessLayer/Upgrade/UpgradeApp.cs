using MyTagPocket.Storage.Repository;
using MyTagPocket.Storage.Upgrade;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Check and upgrade application
  /// </summary>
  public class UpgradeApp : IAsyncResult, IDisposable
  {
    const string classCode = "[1001300]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// List of sections to update
    /// </summary>
    private ObservableCollection<UpgradeInfoList> _UpgradeInfoList;

    /// <summary>
    /// List of storage object to update
    /// </summary>
    private UpgradeInfoList _StorageList;

    /// <summary>
    /// List of database object to update
    /// </summary>
    private UpgradeInfoList _DatabaseIndexList;

    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradeApp()
    {
      _StorageList = new UpgradeInfoList();
      _DatabaseIndexList = new UpgradeInfoList();
      _UpgradeInfoList = new ObservableCollection<UpgradeInfoList>();
    }

    /// <summary>
    /// Init upgrade process
    /// </summary>
    public void InitUpgrade()
    {
      const string methodCode = "[1001305]";
      Log.Trace(methodCode, "Upgrade init upgrade");
      try
      {
        ///Clean upgrade
        _DatabaseIndexList.Clear();
        _StorageList.Clear();
        _UpgradeInfoList.Clear();

        //Initialize upgrade
        _UpgradeInfoList.Add(_StorageList);
        _UpgradeInfoList.Add(_DatabaseIndexList);
        InitStorageList(_StorageList);
        InitDatabaseIndexList(_DatabaseIndexList);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Upgrade init error");
      }
    }

    /// <summary>
    /// Upgrade list category items for upgrade
    /// </summary>
    public ObservableCollection<UpgradeInfoList> UpgradeList
    {
      get
      {
        return _UpgradeInfoList;
      }
      set
      {
        _UpgradeInfoList = value;
      }
    }

    public object AsyncState => throw new NotImplementedException();

    public WaitHandle AsyncWaitHandle => throw new NotImplementedException();

    public bool CompletedSynchronously => throw new NotImplementedException();

    public bool IsCompleted => throw new NotImplementedException();

    /// <summary>
    /// Check actual version application
    /// </summary>
    /// <returns>Tru = actual version</returns>
    public bool ActualVersionApp()
    {
      //Check storage repository on actual version
      var setRepo = new SettingsRepository();
      var verEntity = new Storage.Entities.Settings.Version();
      setRepo.Load(verEntity);
      if (verEntity.Ver != verEntity.GetActuaAssemblylVersion())
        return false;

      //TODO: Check database is actual version
      return true;
    }

    /// <summary>
    /// Start upgrade application
    /// </summary>
    public async Task StartAsync()
    {
      await Task.Run(() =>
      {
        foreach (var item in _UpgradeInfoList)
        {
          item.Start();
        }
      });
    }

    /// <summary>
    /// Init database index upgrade item
    /// </summary>
    /// <param name="databaseIndexList">Database index item list</param>
    private void InitDatabaseIndexList(UpgradeInfoList databaseIndexList)
    {
      const string methodCode = "[1001303]";
      Log.Trace(methodCode, "Upgrade Initialize database index item list");
    }

    /// <summary>
    /// Init storage items for upgrade
    /// </summary>
    /// <param name="storageList"></param>
    private void InitStorageList(UpgradeInfoList storageList)
    {
      const string methodCode = "[1001304]";
      Log.Trace(methodCode, "Upgrade Initialize storage index item list");
      Log.Trace(methodCode, "Add to upgrade list Storage update");
      var storageSettings = new UpgradeStorageSettings();
      var infoStorageSettings = new UpgradeInfo(storageSettings);
      _StorageList.Add(infoStorageSettings);
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
