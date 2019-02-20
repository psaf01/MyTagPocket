using System.Collections.Generic;

namespace MyTagPocket.Dal.Repository.Interface
{
  /// <summary>
  /// Interface Generic repository
  /// </summary>
  /// <typeparam name="T">Table</typeparam>
  public interface IGenericRepository<T>
    where T :new() 
  {

    /// <summary>
    /// Add new object
    /// </summary>
    /// <param name="obj">Object/Table</param>
    /// <returns></returns>
    int Add(T obj);

    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    List<T> Get();

    /// <summary>
    /// Get object 
    /// </summary>
    /// <param name="id">Identificator</param>
    /// <returns></returns>
    T GetByID(object id);

    /// <summary>
    /// Update object
    /// </summary>
    /// <param name="obj">Object</param>
    /// <returns></returns>
    int Update(T obj);

    /// <summary>
    /// Delete object
    /// </summary>
    /// <param name="primaryKey">Identificator</param>
    /// <returns></returns>
    int Delete(object primaryKey);

    int DeleteAll();

    /// <summary>
    /// Actual version table of Entities
    /// </summary>
    int VersionTableEntity { get; } 
  }
}
