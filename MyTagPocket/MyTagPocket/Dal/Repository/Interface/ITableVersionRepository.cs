using MyTagPocket.Dal.Entities;

namespace MyTagPocket.Dal.Repository.Interface
{
  /// <summary>
  /// Interface repository Table Version
  /// </summary>
  public interface ITableVersionRepository : IGenericRepository<TableVersion>
  {
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
    int GetVersion<T>();
  }
}
