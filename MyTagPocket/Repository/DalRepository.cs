namespace MyTagPocket.Repository
{
  using MyTagPocket.CoreUtil.Interfaces;
  using MyTagPocket.DbStorage;
  using MyTagPocket.Repository.Dal.Entities.Devices;
  using MyTagPocket.Repository.Interfaces;
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

    private DalDbLiteRepository dbRepository;

    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// Constructor. Database in memmory.
    /// </summary>
    /// <param name="logManager"></param>
    public DalRepository(ILogManager logManager)
    {
      Log = logManager.GetLog(classCode);
      dbRepository = new DalDbLiteRepository(new DbLiteMemmoryHelper());
    }

    /// <summary>
    /// Constructor. Database in file.
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fullPathToDb">Full path tu database.</param>
    public DalRepository(ILogManager logManager, string fullPathToDb)
    {
      Log = logManager.GetLog(classCode);
      dbRepository = new DalDbLiteRepository(new DbLiteFileHelper(fullPathToDb));
    }

    /// <summary>
    /// Initialize database
    /// </summary>
    public async Task InitilizeDbAsync()
    {
      const string methodCode = "M02";
      await Task.Run(() =>
      {
        Log.Trace(methodCode, $"Initialize database");
        if (dbRepository.GetVersionDb() == 0)
              InitializeMainDbVer1();
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
      await dbRepository.SaveFileAsync(idFile, fileName, stream);
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    public async Task SaveFileAsync(string idFile, string filePath)
    {
      await dbRepository.SaveFileAsync(idFile, filePath);
    }

    public void GetFile(string idFile, string filePath, Stream stream)
    {
      dbRepository.GetFile(idFile, filePath, stream);
    }

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entiy</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    public async Task SaveAsync<T>(T entity)
    {
      await dbRepository.SaveAsync<T>(entity);
    }

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="id">ID entity</param>
    /// <returns>Entity</returns>
    public async Task<T> FindById<T>(int id)
    {
      return await dbRepository.FindById<T>(id);
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
      return await dbRepository.FindAsync<T>(predicate, skip, limit);
    }

    /// <summary>
    /// Find one object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <returns>Object</returns>
    public async Task<T> FindOneAsync<T>(Expression<Func<T, bool>> predicate)
    {
      return await dbRepository.FindOneAsync<T>(predicate);
    }

    /// <summary>
    /// Count entities
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <returns>Count</returns>
    public async Task<int> CountAsync<T>()
    {
      return await dbRepository.CountAsync<T>();
    }
    #region Update database

    /// <summary>
    /// Initialize MyTagPocket database
    /// </summary>
    private void InitializeMainDbVer1()
    {
      const string methodCode = "M01";
      string ver = "v1";
      Log.Trace(methodCode, $"Initialize {ver}");

      var device = new Device();
      Log.Trace(methodCode, $"Initialize collection {ver} {device.GetNameCollection()}");
      var columns = new Dictionary<string, bool>();
      columns.Add(nameof(device.DeviceId), true);
      columns.Add(nameof(device.Name), false);

      dbRepository.CreateNewCollection<Device>(device.GetNameCollection(), columns);
      dbRepository.SetVersionDb(1);
    }
    #endregion Update database
  }
}
