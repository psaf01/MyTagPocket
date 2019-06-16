using System;

namespace MyTagPocket.Repository.Dal.Interface
{
  /// <summary>
  /// Interface database entity base
  /// </summary>
  public interface IDalEntityBase
  {
    /// <summary>
    /// Identificator
    /// </summary>
    long Id { get; set; }

    /// <summary>
    /// Object Identificator
    /// </summary>
    string ObjectId { get; set; }

    /// <summary>
    /// True - Object deleted
    /// </summary>
    bool Deleted { get; set; }
    
    /// <summary>
    ///  Object created
    /// </summary>
    DateTime CreatedWhen { get; set; }

    /// <summary>
    /// Object created who
    /// </summary>
    string CreatedWho { get; set; }

    /// <summary>
    /// Object updated
    /// </summary>
    DateTime UpdatedWhen { get; set; }

    /// <summary>
    /// Object updated who
    /// </summary>
    string UpdatedWho { get; set; }

    /// <summary>
    /// Object Version
    /// </summary>
    long VersionObject { get; set; }
  }
}
