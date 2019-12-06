using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyTagPocket.CoreUtil.Interfaces
{
  /// <summary>
  /// Interface for audit log
  /// </summary>
  public interface IAuditLog
  {
    /// <summary>
    /// Initialize audit log
    /// </summary>
    void InitializeAuditLog();

    /// <summary>
    /// Save audit item
    /// </summary>
    /// <param name="audit">Audit item</param>
    void Save(Repository.Audit.Entities.Audit audit);

    /// <summary>
    /// Get audit items
    /// </summary>
    /// <param name="predicate">Filter predicate</param>
    /// <returns>Audits</returns>
    IEnumerable<Repository.Audit.Entities.Audit> GetAudits(Expression<Func<Repository.Audit.Entities.Audit, bool>> predicate, int skip = 0, int limit = int.MaxValue);


  }
}
