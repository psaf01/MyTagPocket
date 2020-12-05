using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.FileStorage
{
  /// <summary>
  /// Interface file operation
  /// </summary>
  public interface IFile
  {
    /// <summary>
    /// Read text file
    /// </summary>
    /// <param name="path">Full path</param>
    /// <returns>Text content</returns>
    string ReadFile(string path);

    /// <summary>
    /// Read text file
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="encode">Encoding</param>
    /// <returns></returns>
    string ReadFile(string path, Encoding encode);

    /// <summary>
    /// Save text file with encodin UTF8
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="text">Text content</param>
    void SaveFile(string path, string text);

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="text">Text content</param>
    /// <param name="encode">Encodind</param>
    void SaveFile(string path, string text, Encoding encode);


    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    void SaveFileLines(string path, IEnumerable<string> fileContent);

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    void SaveFileLines(string path, IEnumerable<string> fileContent, Encoding encode);

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    void SaveAppendToFile(string path, string content);

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    /// <param name="encode">Encodind</param>
    void SaveAppendToFile(string path, string content, System.Text.Encoding encode);

    /// <summary>
    /// Add text lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    void SaveAppendAllLineToFile(string path, IEnumerable<string> content);

    /// <summary>
    /// Add text lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    /// <param name="encode">Encodind</param>
    void SaveAppendAllLineToFile(string path, IEnumerable<string> content, System.Text.Encoding encode);


    /// <summary>
    /// Check exists the file
    /// </summary>
    /// <param name="path">Full path to the file</param>
    /// <returns></returns>
    bool FileExists(string path);

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <returns>Lines from file</returns>
    IEnumerable<string> LoadFileLines(string path);

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="encode">Encodind</param>
    /// <returns>Lines from file</returns>
    IEnumerable<string> LoadFileLines(string path, System.Text.Encoding encode);

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path to file</param>
    void Delete(string path);
  }
}
