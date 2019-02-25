using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.CoreUtil.Interface
{
  /// <summary>
  /// Helper for files and folders
  /// </summary>
  public interface IFileHelper
  {
    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="type">File type</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file</returns>
    string GetLocalFilePath(FileTypeEnum type, string filename);

    /// <summary>
    /// Get full path for content database
    /// </summary>
    /// <returns></returns>
    string GetPathContentDb();

    /// <summary>
    /// Get full path for application database
    /// </summary>
    /// <returns></returns>
    string GetPathAppDb();

    /// <summary>
    /// Get path for Contents files
    /// </summary>
    /// <returns></returns>
    string GetPathContent();
  }
}
