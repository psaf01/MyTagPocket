using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity = MyTagPocket.Repository.Audit.Entities;

namespace MyTagPocket.Repository.Interfaces
{
  /// <summary>
  /// Interface Audit repository
  /// </summary>
  public interface IAuditRepository
  {
    /// <summary>
    /// Initialize new audit log
    /// </summary>
    Task InitializeAuditLogAsync();

    /// <summary>
    /// Save audit item
    /// </summary>
    /// <param name="audit">Audit item</param>
    void Save(Entity.Audit audit);

    /// <summary>
    /// Delete audit items for year and month
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    void DeleteAuditCollection(int year, int month);

    /// <summary>
    /// Get audit items
    /// </summary>
    /// <param name="predicate">Filter predicate</param>
    /// <returns>Audits</returns>
    IEnumerable<Entity.Audit> GetAudits(int year, int month, Expression<Func<Entity.Audit, bool>> predicate, int skip = 0, int limit = int.MaxValue);
    
    /// <summary>
    /// Get audit items
    /// </summary>
    /// <returns>Audits</returns>
    IEnumerable<Entity.Audit> GetAudits(int year, int month, int skip = 0, int limit = int.MaxValue);

    /// <summary>
    /// Count audit items 
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">Month</param>
    /// <returns>Count audit items</returns>
    int Count(int year, int month);
  }
}
