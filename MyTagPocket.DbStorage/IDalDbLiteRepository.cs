using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTagPocket.DbStorage
{
  /// <summary>
  /// Interface DbLite repository for basic operation
  /// </summary>
  public interface IDalDbLiteRepository
  {
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
    /// 
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    /// <param name="stream">IO stream file content</param>

    void GetFile(string idFile, string filePath, Stream stream);

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entiy</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    Task SaveAsync<T>(T entity);

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <param name="collectionName">Specific collection name</param>
    /// <returns>Task</returns>
    Task SaveAsync<T>(T entity, string collectionName);

    /// <summary>
    /// Insert new entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    Task InsertAsync<T>(T entity);

    /// <summary>
    /// Insert new entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <param name="collectionName">Specific collection name</param>
    /// <returns>Task</returns>
    Task InsertAsync<T>(T entity, string collectionName);

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
    /// <param name="nameCollection">Name collection</param>
    /// <param name="skip">Skip records</param>
    /// <param name="limit">Return max records</param>
    /// <returns>List Entities</returns>
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, string nameCollection, int skip = 0, int limit = int.MaxValue);

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <param name="skip">Skip records</param>
    /// <param name="limit">Return max records</param>
    /// <returns>List Entities</returns>
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue);

    /// <summary>
    /// Find one object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <returns>Object</returns>
    Task<T> FindOneAsync<T>(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Find first object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <returns>Object</returns>
    Task<T> FindFirstAsync<T>();

    /// <summary>
    /// Find last object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <returns>Object</returns>
    Task<T> FindLastAsync<T>();

    /// <summary>
    /// Count entities
    /// </summary>
    /// <param name="collectionName">Collection name</param>
    /// <returns>Count</returns>
    Task<int> CountAsync(string collectionName);

    /// <summary>
    /// Count entities
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <returns>Count</returns>
    Task<int> CountAsync<T>();

    /// <summary>
    /// Actual version Audit database
    /// </summary>
    /// <returns>Version</returns>
    int GetVersionDb();

    /// <summary>
    /// Set new user version LiteDb
    /// </summary>
    /// <param name="newVersion">Number new version</param>
    void SetVersionDb(int newVersion);

    /// <summary>
    /// Create new collection in LiteDb
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="name">Name collection</param>
    /// <param name="indexColumns">Column [name, is unique]</param>
    void CreateNewCollection<T>(string name, IDictionary<string, bool> indexColumns);

    /// <summary>
    /// Delete collection
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="name">Name collection</param>
    void DeleteCollection(string name);

    /// <summary>
    /// Check exist collection
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    bool IsExistCollection(string name);

    /// <summary>
    /// First time initialize database
    /// </summary>
    void InitDatabase();
  }
}
