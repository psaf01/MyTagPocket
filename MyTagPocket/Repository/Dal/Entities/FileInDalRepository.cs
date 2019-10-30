using MyTagPocket.CoreUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Repository.Dal.Entities
{
  public class FileInDalRepository
  {
    /// <summary>
    /// File name
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Identification file
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// File length
    /// </summary>
    public long Length { get; set; }

    /// <summary>
    /// Type Encrypt file
    /// </summary>
    public EncryptTypeEnum Encrypt { get; set; }

  }
}
