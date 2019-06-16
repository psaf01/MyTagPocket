using MyTagPocket.Repository.Dal.Interface;
using SQLite;
using System;

namespace MyTagPocket.Repository.Dal.Entities
{
  /// <summary>
  /// Database entity base
  /// </summary>
  public class DalEntityBase : IDalEntityBase
  {
    /// <summary>
    /// Identificator
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public virtual long Id { get; set; }

    /// <summary>
    /// Object Identificator
    /// </summary>
    [NotNull]
    [Indexed(Name = "IX_General", Order = 1, Unique = true)]
    public virtual string ObjectId { get; set; }

    /// <summary>
    /// True - Object deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    ///  Object created
    /// </summary>
    public DateTime CreatedWhen { get; set; }

    /// <summary>
    /// Object created who
    /// </summary>
    public string CreatedWho { get; set; }

    /// <summary>
    /// Object updated
    /// </summary>
    public DateTime UpdatedWhen { get; set; }

    /// <summary>
    /// Object updated who
    /// </summary>
    public string UpdatedWho { get; set; }

    /// <summary>
    /// Object Version
    /// </summary>
    public long VersionObject { get; set; }
  }
}
