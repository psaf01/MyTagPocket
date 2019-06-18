using MyTagPocket.Dal.Entities;
using MyTagPocket.Repository.Dal.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// Database layer repository
  /// </summary>
  public class DalRepository<T> : IDalRepository<T> where T : class, new()
  {
    const string classCode = "[1002500]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// SQLite database connection
    /// </summary>
    private SQLiteAsyncConnection _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    public DalRepository(SQLiteAsyncConnection db)
    {
      _db = db;
    }

    /// <summary>
    /// Queryable
    /// </summary>
    /// <returns>Queryable</returns>
    public AsyncTableQuery<T> AsQueryable() =>
       _db.Table<T>();

    /// <summary>
    /// Delete object to trash
    /// </summary>
    /// <param name="obj">Entity instance</param>
    /// <returns></returns>
    public async Task<long> Delete(T obj) =>
       await _db.DeleteAsync(obj);

    /// <summary>
    /// Delete object to trash
    /// </summary>
    /// <param name="id">Identificator</param>
    /// <returns></returns>
    public async Task<long> Delete(long id) =>
      await _db.DeleteAsync(id);


    /// <summary>
    /// Get object
    /// </summary>
    /// <returns>Object</returns>
    public async Task<List<T>> Get() =>
             await _db.Table<T>().ToListAsync();

    /// <summary>
    /// Get obcejts
    /// </summary>
    /// <typeparam name="TValue">Value</typeparam>
    /// <param name="predicate">Predicate </param>
    /// <param name="orderBy">Order by</param>
    /// <returns>List objects</returns>
    public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
    {
      var query = _db.Table<T>();

      if (predicate != null)
        query = query.Where(predicate);

      if (orderBy != null)
        query = query.OrderBy<TValue>(orderBy);

      return await query.ToListAsync();
    }

    /// <summary>
    /// Get object
    /// </summary>
    /// <param name="id">Identification object</param>
    /// <returns>Object</returns>
    public async Task<T> Get(long id) =>
              await _db.FindAsync<T>(id);

    /// <summary>
    /// Get object
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <returns>Object</returns>
    public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
               await _db.FindAsync<T>(predicate);


    /// <summary>
    /// Inserr object
    /// </summary>
    /// <param name="entity">Object</param>
    /// <returns>Identificator object</returns>
    public async Task<long> Insert(T obj) =>
             await _db.InsertAsync(obj);

    /// <summary>
    /// Update object
    /// </summary>
    /// <param name="obj">Object</param>
    /// <returns>Identificator object</returns>
    public async Task<long> Update(T obj) =>
         await _db.UpdateAsync(obj);

    /// <summary>
    /// Get version table
    /// </summary>
    /// <param name="tableName">Table Name</param>
    /// <returns>0 = Definition table not exists</returns>
    public int GetVersion(string tableName)
    {
      const string methodCode = "[1000301]";
      try
      {
        var ver = _db.Table<TableVersion>().Where(x => x.TableName == tableName).FirstOrDefaultAsync();
        if (ver == null)
        {
          Log.Error(methodCode, $"GetVersion not found definition table [{tableName}]");
          return 0;
        }
        return ver.Result.ActualVersion;
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"GetVersion table [{tableName}] exception [{ex.Message}]");
        throw ex;
      }
    }

    /// <summary>
    /// Get version actual table
    /// </summary>
    /// <param name="obj">Entity for test version</param>
    /// <returns>Version</returns>
    public int GetVersion(T obj)
    {
      return GetVersion(typeof(T).Name);
    }
  }
}
