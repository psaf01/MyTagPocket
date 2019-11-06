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
    /// Version object file history info
    /// </summary>
    int Version { get; set; }

    /// <summary>
    /// GUID file
    /// </summary>
    string FileId { get; set; }

    /// <summary>
    /// GUID folder
    /// </summary>
    string FolderId { get; set; }

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
    string CreatedDate { get; set; }

    /// <summary>
    /// Start position content binary in archive file
    /// </summary>
    int StartPosition { get; set; }

    /// <summary>
    /// Length content
    /// </summary>
    int LengthContent { get; set; }

    /// <summary>
    /// Entity update who Fullname
    /// </summary>
    string CreatedWhoFullname { get; set; }

    /// <summary>
    /// Entity update who e-mail
    /// </summary>
    string CreatedWhoEmail { get; set; }

    /// <summary>
    /// Identification who created
    /// </summary>
    string CreatedWhoId { get; set; }

    /// <summary>
    /// Name of device
    /// </summary>
    string CreatedOnDeviceName { get; set; }

    /// <summary>
    /// Identification 
    /// </summary>
    string CreatedOnDeviceId { get; set; }
  }
}
