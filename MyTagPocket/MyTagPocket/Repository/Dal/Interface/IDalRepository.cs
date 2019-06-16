using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyTagPocket.Repository.Dal.Interface
{
  /// <summary>
  /// Interface Generic repository
  /// </summary>
  /// <typeparam name="T">Table</typeparam>
  public interface IDalRepository<T>
    where T : new()
  {
    /// <summary>
    /// Get all records
    /// </summary>
    /// <param name="navigationProperties">Navigation properties</param>
    /// <returns>List records</returns>
    IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

    /// <summary>
    /// Get list records
    /// </summary>
    /// <param name="where">Where conditions</param>
    /// <param name="navigationProperties">Navigation properties</param>
    /// <returns>List records</returns>
    IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

    /// <summary>
    /// Get single record
    /// </summary>
    /// <param name="where">Where conditions</param>
    /// <param name="navigationProperties">Navigation properties</param>
    /// <returns>Record</returns>
    T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

    /// <summary>
    /// Add new object
    /// </summary>
    /// <param name="obj">Object</param>
    /// <returns></returns>
    int Add(T obj);

    /// <summary>
    /// Add new objects
    /// </summary>
    /// <param name="objets">List objects</param>
    /// <returns>Added new objects</returns>
    IList<T> Add(IList<T> objets);

    /// <summary>
    /// Get object 
    /// </summary>
    /// <param name="objectId">Object Identificator</param>
    /// <returns></returns>
    T GetByObjectId(string objectId);

    /// <summary>
    /// Get object
    /// </summary>
    /// <param name="id">Identificator</param>
    /// <returns></returns>
    T GetById(object id);

    /// <summary>
    /// Update object
    /// </summary>
    /// <param name="obj">Object</param>
    /// <returns>Identificator</returns>
    int Update(T obj);

    /// <summary>
    /// Update objects
    /// </summary>
    /// <param name="objects">List objects</param>
    /// <returns>Update objects</returns>
    IList<T> Update(IList<T> objects);

    /// <summary>
    /// Delete object to trash
    /// </summary>
    /// <param name="id">Identificator</param>
    /// <returns></returns>
    int Delete(object id);

    /// <summary>
    /// Delete object from trash. Not recovery.
    /// </summary>
    /// <param name="id"></param>
    void DeleteTrash(object id);

    /// <summary>
    /// Delete objects from trash. Not recovery.
    /// </summary>
    /// <param name="objects"></param>
    void DeleteTrash(IList<T> objects);
    /// <summary>
    /// Delete objects
    /// </summary>
    /// <param name="objects">List objects</param>
    /// <returns></returns>
    IList<T> Delete(IList<T> objects);

    /// <summary>
    /// Delete all objects
    /// </summary>
    /// <returns></returns>
    void DeleteAll();

    /// <summary>
    /// Delete all objects from trash
    /// </summary>
    void DeleteAllTrash();

    /// <summary>
    /// Actual version table of Entities
    /// </summary>
    int VersionTableEntity { get; }
  }
}
