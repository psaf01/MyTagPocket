using MyTagPocket.Repository.File.Interface;

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
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Entity instance</param>
    void Save(IFileEntityBase entity);

    /// <summary>
    /// Load antity from repository
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Entity instance</param>
    void Load(IFileEntityBase entity);
  }
}
