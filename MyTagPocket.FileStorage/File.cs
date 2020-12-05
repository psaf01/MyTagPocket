using System.Collections.Generic;
using System.IO.Abstractions;

namespace MyTagPocket.FileStorage
{
  /// <summary>
  /// Operation with files
  /// </summary>
  public class File : IFile
  {
    /// <summary>
    /// Encoding file
    /// </summary>
    private System.Text.Encoding encoding = System.Text.Encoding.UTF8;

    /// <summary>
    /// File system on device
    /// </summary>
    private IFileSystem fs;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fileSystem">File system storgage</param>
    public File(IFileSystem fileSystem)
    {
      fs = fileSystem;
    }

    /// <summary>
    /// Read text file with encoding UTF8
    /// </summary>
    /// <param name="path">Full path</param>
    /// <returns>Text content</returns>
    public string ReadFile(string path)
    {
      return ReadFile(path, encoding);
    }

    /// <summary>
    /// Read text file
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="encode">Encoding</param>
    /// <returns></returns>
    public string ReadFile(string path, System.Text.Encoding encode)
    {
      return fs.File.ReadAllText(path, encode);
    }

    /// <summary>
    /// Save text file with encodin UTF8
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="text">Text content</param>
    public void SaveFile(string path, string text)
    {
      SaveFile(path, text, encoding);
    }

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="text">Text content</param>
    /// <param name="encode">Encodind</param>
    public void SaveFile(string path, string text, System.Text.Encoding encode)
    {
      var folder = fs.Path.GetDirectoryName(path);
      if (!fs.Directory.Exists(folder))
        fs.Directory.CreateDirectory(folder);

      fs.File.WriteAllText(path, text, encode);
    }

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    public void SaveFileLines(string path, IEnumerable<string> fileContent)
    {
      SaveFileLines(path, fileContent, encoding);
    }

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    /// <param name="encode">Encodind</param>
    public void SaveFileLines(string path, IEnumerable<string> fileContent, System.Text.Encoding encode)
    {
      fs.File.WriteAllLines(path, fileContent, encode);
    }

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    public void SaveAppendToFile(string path, string content)
    {
      SaveAppendToFile(path, content, encoding);
    }

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    /// <param name="encode">Encodind</param>
    public void SaveAppendToFile(string path, string content, System.Text.Encoding encode)
    {
      fs.File.AppendAllText(path, content, encode);
    }

    /// <summary>
    /// Add text lines to file
    /// </summary>
    /// </summary <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    public void SaveAppendAllLineToFile(string path, IEnumerable<string> content)
    {
      SaveAppendAllLineToFile(path, content, encoding);
    }

    /// <summary>
    /// Add text lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    /// <param name="encode">Encodind</param>
    public void SaveAppendAllLineToFile(string path, IEnumerable<string> content, System.Text.Encoding encode)
    {
      fs.File.AppendAllLines(path, content, encode);
    }

    /// <summary>
    /// Check exists the file
    /// </summary>
    /// <param name="path">Full path to the file</param>
    /// <returns></returns>
    public bool FileExists(string path)
    {
      return fs.File.Exists(path);
    }

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <returns>Lines from file</returns>
    public IEnumerable<string> LoadFileLines(string path)
    {
     return  LoadFileLines(path, encoding);
    }

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="encode">Encodind</param>
    /// <returns>Lines from file</returns>
    public IEnumerable<string> LoadFileLines(string path, System.Text.Encoding encode)
    {
      return fs.File.ReadLines(path, encoding);
    }

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path to file</param>
    public void Delete(string path)
    {
      if (fs.File.Exists(path))
        fs.File.Delete(path);
    }
  }
}
