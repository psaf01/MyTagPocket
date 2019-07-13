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
    /// <param name="fileType">File of type</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    string GetLocalFilePath(DataTypeEnum fileType, string filename);

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
