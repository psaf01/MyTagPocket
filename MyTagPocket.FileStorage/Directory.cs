using System.IO.Abstractions;

namespace MyTagPocket.FileStorage
{
  /// <summary>
  /// Operation with directory
  /// </summary>
  public class Directory : IDirectory
  {
    private IFileSystem fs;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fileSystem">File system</param>
    public Directory(IFileSystem fileSystem)
    {
      fs = fileSystem;
    }

    /// <summary>
    /// Check exists the folder
    /// </summary>
    /// <param name="path">Full path to the folder</param>
    /// <returns></returns>
    public bool FolderExists(string path)
    {
      return fs.Directory.Exists(path);
    }

    /// <summary>
    /// Delete folder
    /// </summary>
    /// <param name="folder">Full path folder</param>
    public void DeleteFolder(string folder)
    {
      if (fs.Directory.Exists(folder))
        fs.Directory.Delete(folder);
    }
  }
}
