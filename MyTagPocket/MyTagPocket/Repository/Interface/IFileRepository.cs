using MyTagPocket.Repository.File.Interface;
using System.Threading.Tasks;

namespace MyTagPocket.Repository.Interface
{
  /// <summary>
  /// Interface repository
  /// </summary>
  public interface IFileRepository
  {
    /// <summary>
    /// Save entity to respository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    /// <returns>Async Task</returns>
    Task SaveAsync<T>(IFileEntityBase<T> entity);

    /// <summary>
    /// Load entity from repository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    /// <typeparam name="T">Entity type</typeparam>
    /// <returns>Entity base from repository</returns>
    Task<T> LoadAsync<T>(IFileEntityBase<T> entity);

    /// <summary>
    /// Delete entity from repository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    Task DeleteAsync<T>(IFileEntityBase<T> entity);

    /// <summary>
    /// Save entity to archive
    /// </summary>
    /// <param name="entity">Entity instance</param>
    Task SaveToArchiveAsync<T>(IFileEntityBase<T> entity);

    /// <summary>
    /// Load entity from archive
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<IFileEntityBase<T>> LoadArchiveAsync<T>(IFileEntityBase<T> entity);
  }
}
