namespace MyTagPocket.Repository
{
  using LiteDB;
  using MyTagPocket.CoreUtil;
  using MyTagPocket.CoreUtil.Exceptions;
  using MyTagPocket.CoreUtil.Interfaces;
  using MyTagPocket.Repository.Dal.Entities.Devices;
  using MyTagPocket.Repository.Dal.Entities.Settings;
  using MyTagPocket.Repository.Dal.Entities.Users;
  using MyTagPocket.Repository.Dal.Interface;
  using MyTagPocket.Repository.Interfaces;
  using MyTagPocket.Resources;
  using NeoSmart.AsyncLock;
  using System;
  using System.IO;
  using System.Threading.Tasks;

  /// <summary>
  /// Database repository
  /// </summary>
  public class DalRepository : IDalRepository
  {
    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10034";

    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// Database helper instance
    /// </summary>
    public static IDalHelper DalHelper { get; set; }

    AsyncLock lockObject = new AsyncLock();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fileHelper">File helper</param>
    public DalRepository(ILogManager logManager, IDalHelper dalHelper)
    {
      Log = logManager.GetLog(classCode);
      DalHelper = dalHelper;
    }

    /// <summary>
    /// Initialize database
    /// </summary>
    public async Task InitilizeDbAsync()
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            if (db.Engine.UserVersion == 0)
              InitializeMainDbVer1(db);
          }
        }
      });
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="fileName">File name</param>
    /// <param name="stream">IO stream file content</param>
    public void SaveFile(string idFile, string fileName, Stream stream)
    {
      if (string.IsNullOrEmpty(idFile))
        throw new ErrorException(ResourceApp.ExceptionDalRepositorySaveFileIdFileEmpty);

      if (string.IsNullOrEmpty(fileName))
        throw new ErrorException(ResourceApp.ExceptionDalRepositorySaveFileName);

      liteDb.FileStorage.Upload(idFile, fileName, stream);
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    public void SaveFile(string idFile, string filePath)
    {
      var file = liteDb.FileStorage.Upload(idFile, filePath);
    }

    public void GetFile(string idFile, string filePath, Stream stream)
    {
      /*
      var file = Db.FileStorage.Download(idFile, stream);
      {
        if (string.IsNullOrEmpty(idFile))
          throw new ArgumentNullException("id");
        if (stream == null) throw new ArgumentNullException("stream");

        using (var s = this.OpenRead(id))
        {
          if (s == null) throw new LiteException("File not found");

          s.CopyTo(stream);
        }
      }
      */
    }

    public void Save(IDalBase entity)
    {
      throw new NotImplementedException();
    }

    public IDalBase Load(string entityId)
    {
      throw new NotImplementedException();
    }

    #region Update database
    /// <summary>
    /// Initialize MyTagPocket database
    /// </summary>
    private void InitializeMainDbVer1(LiteDatabase db)
    {
      const string methodCode = "M01";
      Log.Trace(methodCode, "Initialize database");

      
      db.Engine.EnsureIndex(setting.GetNameCollection, nameof(setting.Name), true);
      
      db.Engine.EnsureIndex(device.GetNameCollection, nameof(device.DeviceId), true);
      //User user

      db.Engine.UserVersion = 1;
    }
    #endregion Update database
  }
}
