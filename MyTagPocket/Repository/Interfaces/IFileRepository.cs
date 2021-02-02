using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.Files.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTagPocket.Repository.Interfaces
{
  /// <summary>
  /// Interface repository
  /// </summary>
  public interface IFileRepository
  {
    /// <summary>
    /// Load entity from repository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    /// <typeparam name="T">Entity type</typeparam>
    /// <returns>Entity base from repository</returns>
    Task<T> LoadAsync<T>(IFileEntityBase<T> entity);

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    /// <param name="path">Path to folder where entity save</param>
    Task SaveAsync<T>(IFileEntityBase<T> entity, string path);

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    /// <param name="toArchive">Save entity to archive too</param>
    //Task SaveAsync<T>(IFileEntityBase<T> entityNew);

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    /// <param name="toArchive">Save entity to archive too</param>
    //Task SaveAsync<T>(IFileEntityBase<T> entityNew, IFileEntityBase<T> entityOld);

    /// <summary>
    /// Load entity file from archive
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="fileInfo">Info about file from history</param>
    //Task<T> LoadFromArchivAsync<T>(IFileHistoryInfo fileInfo);

    /// <summary>
    /// Load history save of file entity
    /// </summary>
    /// <typeparam name="T">Type File entity</typeparam>
    /// <param name="entity">Entity object</param>
    /// <returns>List of file entity history</returns>
    //Task<IEnumerable<IFileHistoryInfo>> LoadHistoryAsync<T>(IFileEntityBase<T> entity);

    /// <summary>
    /// Delete entity from repository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    Task DeleteAsync<T>(IFileEntityBase<T> entity);
/*
    /// <summary>
    /// Load entity from archive
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<IFileEntityBase<T>> LoadArchiveAsync<T>(IFileEntityBase<T> entity);
    */
  }
}
