using System;

namespace MyTagPocket.Repository.Audit.Entities
{
  /// <summary>
  /// Database collection for audit
  /// </summary>
  public class AuditDbCollection : AuditBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public AuditDbCollection() : base(nameCollectionEntity: "AuditDbCollection")
    {
    }

    /// <summary>
    /// CollectionName
    /// </summary>
    public string CollectionName { get; set; }

    /// <summary>
    /// Dat time created 
    /// </summary>
    public DateTimeOffset CreatedWhen { get; set; } 
  }
}
