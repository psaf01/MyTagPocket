using MyTagPocket.Models.Settings;
using MyTagPocket.Repository.Interfaces;

namespace MyTagPocket
{
  /// <summary>
  /// Application global variables
  /// </summary>
  public static class AppGlobal
  {
    /// <summary>
    /// Initialize application global variables
    /// </summary>
    public static void Init(ISettingRepository setttingRepository)
    {
      CurrentFolders folder = new CurrentFolders(setttingRepository);
      Folders = folder;
      Folders.Init();

      CurrentDevice device = new CurrentDevice(setttingRepository, Folders.DevicesGuid);
      Device = device;
      Device.Init();

      CurrentUser userSystem = new CurrentUser(setttingRepository, Folders.UsersGuid);
      UserSystem = userSystem;
      UserSystem.Init();

      CurrentUser user = new CurrentUser(setttingRepository, Folders.UsersGuid);
      User = user;
      User.Init();

      SettingLog log = new SettingLog(setttingRepository);
      Log = log;
      Log.Init();
    }

    /// <summary>
    /// Current use device
    /// </summary>
    public static CurrentDevice Device { get; set; }

    /// <summary>
    /// Current login user in application
    /// </summary>
    public static CurrentUser User { get; set; }

    /// <summary>
    /// The current device/system user that is used for automated operations
    /// </summary>
    public static CurrentUser UserSystem { get; set; }

    /// <summary>
    /// Current directories for writing or read file entities
    /// </summary>
    public static CurrentFolders Folders{get;set;}

    /// <summary>
    /// Settin for logging, auditing etc
    /// </summary>
    public static SettingLog Log { get; set; }
  }
}
