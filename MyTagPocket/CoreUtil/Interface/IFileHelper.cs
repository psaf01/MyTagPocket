using System.Collections.Generic;
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

    /// <summary>Abstractions.IFileSystem
    /// Get local folder path
    /// </summary>
    /// <param name="type">File type</param>
    /// <returns>Full path folder</returns>
    string GetLocalFolderPath(DataTypeEnum type);

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileTypeValue">Idnetification file type</param>
    /// <param name="subFolder">Generic subfolder</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    string GetLocalFilePath(string fileTypeValue, string subFolder, string filename);
    
    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileType">File of type</param>
    /// <param name="subFolder">Generic subfolder</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    string GetLocalFilePath(DataTypeEnum fileType, string subFolder, string filename);

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    void SaveFile(string path, string fileContent);

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    void SaveFileLines(string path, IEnumerable<string> fileContent);

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    void SaveAppendToFile(string path, string content);

    /// <summary>
    /// Add binary data to file 
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Content</param>
    void SaveAppendToFile(string path, byte[] content);

    /// <summary>
    /// Add text lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    void SaveAppendAllLineToFile(string path, IEnumerable<string> content);

    /// <summary>
    /// Check exists the file
    /// </summary>
    /// <param name="path">Full path to the file</param>
    /// <returns></returns>
    bool FileExists(string path);

    /// <summary>
    /// Check exists the folder
    /// </summary>
    /// <param name="path">Full path to the folder</param>
    /// <returns></returns>
    bool FolderExists(string path);

    /// <summary>
    /// Load text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    /// <returns>True = load ok</returns>
    string LoadFile(string path);

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <returns>Lines from file</returns>
    IEnumerable<string> LoadFileLines(string path);

    /// <summary>
    /// Load contet from file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="startPosition">Position from where to start reading</param>
    /// <param name="lengthContent">Length of content to be read</param>
    /// <returns></returns>
    byte[] LoadContentFromFile(string path, int startPosition, int lengthContent);

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path to file</param>
    void DeleteFile(string path);
  }

}
