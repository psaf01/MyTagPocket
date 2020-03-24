using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTagPocket.Repository.Interfaces
{
  /// <summary>
  /// Interface Database repository
  /// </summary>
  public interface IDalRepository
  {
    /// <summary>
    /// Initialize database
    /// </summary>
    Task InitilizeDbAsync();

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="fileName">File name</param>
    /// <param name="stream">IO stream file content</param>
    Task SaveFileAsync(string idFile, string fileName, Stream stream);

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    Task SaveFileAsync(string idFile, string filePath);

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entiy</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    Task SaveAsync<T>(T entity);

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="id">ID entity</param>
    /// <returns>Entity</returns>
    Task<T> FindById<T>(int id);

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <param name="skip">Skip records</param>
    /// <param name="limit">Return max records</param>
    /// <returns>List Entities</returns>
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue);

    Task<T> FindOneAsync<T>(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Count entities
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <returns>Count</returns>
    Task<int> CountAsync<T>();
  }
}
