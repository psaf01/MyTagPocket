using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Repository.File.Interface
{
  /// <summary>
  /// Interface Information about File history 
  /// </summary>
  public interface IFileHistoryInfo
  {
    /// <summary>
    /// GUID file
    /// </summary>
    string FileId { get; set; }

    /// <summary>
    /// File type 
    /// </summary>
    string FileType { get; set; }

    /// <summary>
    /// GUID Commit
    /// </summary>
    string CommitId { get; set; }

    /// <summary>
    /// Create date commit
    /// </summary>
    string CreateDate { get; set; }

    /// <summary>
    /// Start position content binary in archive file
    /// </summary>
    int StartPosition { get; set; }

    /// <summary>
    /// Length content
    /// </summary>
    int LengthContent { get; set; }

    /// <summary>
    /// Entity update who
    /// </summary>
    string CreatedWho { get; set; }
  }
}
