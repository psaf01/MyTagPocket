using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.FileStorage
{
  /// <summary>
  /// Interface directory operation
  /// </summary>
  public interface IDirectory
  {
    /// <summary>
    /// Check exists the folder
    /// </summary>
    /// <param name="path">Full path to the folder</param>
    /// <returns></returns>
    bool FolderExists(string path);


    /// <summary>
    /// Delete folder
    /// </summary>
    /// <param name="folder">Full path folder</param>
    void DeleteFolder(string folder);
  }
}
