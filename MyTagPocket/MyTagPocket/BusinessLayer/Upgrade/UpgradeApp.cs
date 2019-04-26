using System;
using System.Collections.ObjectModel;
using System.IO.Abstractions;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Check and upgrade application
  /// </summary>
  public class UpgradeApp
  {
    const string classCode = "[1001300]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// File system
    /// </summary>
    private IFileSystem _FileSystem;

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
    /// <param name="storageFileSystem">File System</param>
    public UpgradeApp(IFileSystem fileSystem)
    {
      _FileSystem = fileSystem;
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

    /// <summary>
    /// Check actual version application
    /// </summary>
    /// <returns>Tru = actual version</returns>
    public bool ActualVersionApp()
    {
      //TODO: Add code for check actual version
      return false;
    }

    /// <summary>
    /// Check version and upgrade storage
    /// </summary>
    [Obsolete]
    public void CheckAndUpgradeStorage()
    {
      const string methodCode = "[1001301]";
      Log.Trace(methodCode, "Start Check and upgrade storage");
      //var upgradeStorageContents = new UpgradeStorageContents(_FileSystem);
      //var upgradeStorageSettings = new UpgradeStorageSettings(_FileSystem);
      //var upgradeStorage = new UpgradeStorage(upgradeStorageSettings, upgradeStorageContents);
      //upgradeStorage.CheckAndUpgrade();
      Log.Trace(methodCode, "End Check and upgrade storage");
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
    }
  }
}
