namespace MyTagPocket.Repository
{
  using LiteDB;
  using MyTagPocket.CoreUtil.Exceptions;
  using MyTagPocket.CoreUtil.Interfaces;
  using MyTagPocket.Repository.Dal.Entities.Devices;
  using MyTagPocket.Repository.Interfaces;
  using MyTagPocket.Resources;
  using NeoSmart.AsyncLock;
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq.Expressions;
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
            //if (db.Engine.UserVersion == 0)
            //  InitializeMainDbVer1(db);
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
    public async Task SaveFileAsync(string idFile, string fileName, Stream stream)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            if (string.IsNullOrEmpty(idFile))
              throw new ErrorException(ResourceApp.ExceptionDalRepositorySaveFileIdFileEmpty);

            if (string.IsNullOrEmpty(fileName))
              throw new ErrorException(ResourceApp.ExceptionDalRepositorySaveFileName);

            db.FileStorage.Upload(idFile, fileName, stream);
          }
        }
      });
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    public async Task SaveFileAsync(string idFile, string filePath)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            db.FileStorage.Upload(idFile, filePath);
          }
        }
      });
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

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entiy</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    public async Task SaveAsync<T>(T entity)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            dbCol.Upsert((T)entity);
          }
        }
      });
    }

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="id">ID entity</param>
    /// <returns>Entity</returns>
    public async Task<T> FindById<T>(int id)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            return dbCol.FindById(id);
          }
        }
      });
    }

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <param name="skip">Skip records</param>
    /// <param name="limit">Return max records</param>
    /// <returns>List Entities</returns>
    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            return dbCol.Find(predicate, skip, limit);
          }
        }
      });
    }

    /// <summary>
    /// Count entities
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <returns>Count</returns>
    public async Task<int> CountAsync<T>()
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            return dbCol.Count();
          }
        }
      });
    }
    #region Update database
    /// <summary>
    /// Initialize MyTagPocket database
    /// </summary>
    private void InitializeMainDbVer1(LiteDatabase db)
    {
      const string methodCode = "M01";
      Log.Trace(methodCode, "Initialize database");
      /*
      var dbColl = db.Engine.GetCollectionNames();
      int dbCollCount = 0;
      var findDeviceColl = false;
      var dateTime = DateTimeOffset.Now;
      var device = new Device();
      foreach (var collName in dbColl)
      {
        if (collName == device.GetNameCollection)
          findDeviceColl = true;

        dbCollCount++;
      }

      if (!findDeviceColl)
      {
        db.Engine.EnsureIndex(device.GetNameCollection, nameof(device.DeviceId), true);
        db.Engine.EnsureIndex(device.GetNameCollection, nameof(device.Name), true);
      }

      db.Engine.UserVersion = 1;
      */
    }
    #endregion Update database
  }
}
