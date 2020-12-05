using System.IO.Abstractions;

namespace MyTagPocket.FileStorage
{
  /// <summary>
  /// File system
  /// </summary>
  public class FileSystem
  {
    private IFile file;
    private IDirectory directory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="storage">File operation system</param>
    public FileSystem(IFileSystem storage)
    {
      file = new File(storage);
      directory = new Directory(storage);
    }
    
    /// <summary>
    /// File operation
    /// </summary>
    public IFile File { get => file; }

    /// <summary>
    /// Directory operation
    /// </summary>
    public IDirectory Directory { get => directory; }
  }
}
