using MyTagPocket.Dal.Repository.Interface;
using SQLite;
using System.Collections.Generic;

namespace MyTagPocket.Dal.Repository
{
  /// <summary>
  /// General methods for Entities in repository
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class GenericRepository<T> : IGenericRepository<T>
    where T : new()
  {
    SQLiteConnection db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Database connection for SQLite</param>
    public GenericRepository(SQLiteConnection db)
    {
      this.db = db;
      if (!this.db.IsInTransaction)
      {
        this.db.BeginTransaction();
      }
    }

    /// <summary>
    /// Add new object to table
    /// </summary>
    /// <param name="obj">Entity object</param>
    /// <returns></returns>
    public virtual int Add(T obj)
    {
      return db.Insert(obj);
    }

    /// <summary>
    /// Get list object
    /// </summary>
    /// <returns></returns>
    public virtual List<T> Get()
    {
      return db.Table<T>().ToList();
    }

    /// <summary>
    /// Get by ID
    /// </summary>
    /// <param name="id">Identificator</param>
    /// <returns></returns>
    public virtual T GetByID(object id)
    {
      return db.Find<T>(id);
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="obj">Object</param>
    /// <returns></returns>
    public virtual int Update(T obj)
    {
      return db.Update(obj);
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="objPrimaryKey">Object</param>
    /// <returns></returns>
    public virtual int Delete(object objPrimaryKey)
    {
      return db.Delete<T>(objPrimaryKey);
    }

    /// <summary>
    /// Delete all objects
    /// </summary>
    /// <returns></returns>
    public virtual int DeleteAll()
    {
      return db.DeleteAll<T>();
    }

    /// <summary>
    /// Actual version table of Entities
    /// </summary>
    public virtual int VersionTableEntity
    {
      get
      {
        return 0;
      }
    }
    
  }
}
