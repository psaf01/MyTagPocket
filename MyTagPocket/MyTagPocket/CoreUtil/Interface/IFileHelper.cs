using System.IO.Abstractions;
using System.Threading.Tasks;

namespace MyTagPocket.CoreUtil.Interface
{
  /// <summary>
  /// Helper for files and folders in file system on device
  /// </summary>
  public interface IFileHelper
  {

    /// <summary>
    /// File system on device
    /// </summary>
    IFileSystem FileSystemStorage { get; set; }

    /// <summary>
    /// Get local folder path
    /// </summary>
    /// <param name="type">File type</param>
    /// <returns>Full path folder</returns>
    string GetLocalFolderPath(DataTypeEnum type);

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="type">File type</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file</returns>
    string GetLocalFilePath(DataTypeEnum type, string filename);

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

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Text content file for save</param>
    Task SaveFile(string path, string fileContent);

    /// <summary>
    /// Load text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <returns>Text context</returns>
    Task<string> LoadFile(string path);

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path file</param>
    Task DeleteFile(string path);
  }
}
