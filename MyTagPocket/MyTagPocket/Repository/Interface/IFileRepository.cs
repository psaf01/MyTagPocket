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
    Task Save(IFileEntityBase entity);

    /// <summary>
    /// Load entity from repository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    Task Load(IFileEntityBase entity);

    /// <summary>
    /// Delete entity from repository
    /// </summary>
    /// <param name="entity">Entity instance</param>
    Task Delete(IFileEntityBase entity);

    /// <summary>
    /// Save entity to archive
    /// </summary>
    /// <param name="entity">Entity instance</param>
    Task SaveToArchive(IFileEntityBase entity);
  }
}
