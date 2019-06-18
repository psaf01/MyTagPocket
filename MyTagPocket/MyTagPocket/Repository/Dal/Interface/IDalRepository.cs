using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MyTagPocket.Repository.Dal.Interface
{
  /// <summary>
  /// Interface Generic repository
  /// </summary>
  /// <typeparam name="T">Table</typeparam>
  public interface IDalRepository<T> where T : class, new()
  {
    /// <summary>
    /// Get all records
    /// </summary>
    /// <returns></returns>
    Task<List<T>> Get();

    /// <summary>
    /// Get records
    /// </summary>
    /// <typeparam name="TValue">Entity</typeparam>
    /// <param name="predicate">Predicate </param>
    /// <param name="orderBy">Order</param>
    /// <returns></returns>
    Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);

    /// <summary>
    /// Get record
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <returns></returns>
    Task<T> Get(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Get record
    /// </summary>
    /// <param name="id">Identificate record</param>
    /// <returns></returns>
    Task<T> Get(long id);

    /// <summary>
    /// Queryable(
    /// </summary>
    /// <returns>Queryable(</returns>
    SQLite.AsyncTableQuery<T> AsQueryable();

    /// <summary>
    /// Add new objects
    /// </summary>
    /// <param name="objets">List objects</param>
    /// <returns>Identificaton new objects</returns>
    Task<long> Insert(T obj);

    /// <summary>
    /// Update object
    /// </summary>
    /// <param name="entity">Object</param>
    /// <returns>Identification object</returns>
    Task<long> Update(T obj);

    /// <summary>
    /// Delete object to trash
    /// </summary>
    /// <param name="obj">Entity instance</param>
    /// <returns></returns>
    Task<long> Delete(T obj);

    /// <summary>
    /// Delete object to trash
    /// </summary>
    /// <param name="id">Identificator</param>
    /// <returns></returns>
    Task<long> Delete(long id);

    /// <summary>
    /// Get actual version table
    /// </summary>
    /// <param name="tableName">Table name</param>
    /// <returns>Version table</returns>
    int GetVersion(string tableName);

    /// <summary>
    /// Get actual version object table
    /// </summary>
    /// <typeparam name="T">Entity table</typeparam>
    /// <returns>Version table</returns>
    int GetVersion(T obj);
  }
}
