using MyTagPocket.CoreUtil;
using System;

namespace MyTagPocket.Repository.File.Interface
{
  /// <summary>
  /// Interface file entities base for
  /// </summary>
  public interface IFileEntityBase
  {
    /// <summary>
    /// Identification entity
    /// </summary>
    string EntityId { get; set; }

    /// <summary>
    /// Identification commit
    /// </summary>
    string CommitId { get; set; }

    /// <summary>
    /// Get type entity
    /// </summary>
    DataTypeEnum TypeEntity { get; set; }

    /// <summary>
    /// Entity created when
    /// </summary>
    DateTime CreatedWhen { get; set; }

    /// <summary>
    /// Entity updated when
    /// </summary>
    DateTime UpdatedWhen { get; set; }

    /// <summary>
    /// Entity update who
    /// </summary>
    string CreatedWho { get; set; }

    /// <summary>
    /// Entity updated who
    /// </summary>
    string UpdatedWho { get; set; }

    /// <summary>
    /// Hash entity
    /// </summary>
    string Hash { get; set; }

    /// <summary>
    /// Encrypt file
    /// </summary>
    EncryptTypeEnum Encrypt { get; set; }

    /// <summary>
    /// Get actual hash from entity 
    /// </summary>
    /// <returns></returns>
    string GetActualHash();

  }
}
