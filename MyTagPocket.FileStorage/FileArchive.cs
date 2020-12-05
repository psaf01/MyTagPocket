using System.IO.Abstractions;

namespace MyTagPocket.FileStorage
{
  /// <summary>
  /// Interface for opoerations with archive files
  /// </summary>
  public class FileArchive : IFileArchive
  {
    /// <summary>
    /// File system on device
    /// </summary>
    private IFileSystem fs;

    public FileArchive(IFileSystem fileSystem)
    {
      fs = fileSystem;
    }
  }
}
