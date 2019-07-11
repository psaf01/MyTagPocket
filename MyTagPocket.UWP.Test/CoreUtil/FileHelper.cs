using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.UWP.Test.CoreUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace MyTagPocket.UWP.Test.CoreUtil
{
  /// <summary>
  /// File helper for UWP application
  /// </summary>
  public class FileHelper : IFileHelper
  {
    const string classCode = "[9001200]";
    public static Interface.ILogger Log = DependencyService.Get<Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Encoding file
    /// </summary>
    private System.Text.Encoding _Encoding = System.Text.Encoding.UTF8;

    /// <summary>
    /// File system on device
    /// </summary>
    public IFileSystem FileSystemStorage { get; set; }

    /// <summary>
    /// Fake root application path
    /// </summary>
    private const string _RootTestApp = @"c:\MyTagPocket";

    /// <summary>
    /// Constructor
    /// </summary>
    public FileHelper()
    {
      if (MockFileSystemStorage.UseMockFileSystem)
        FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      else
        FileSystemStorage = new FileSystem();
    }

    /// <summary>Abstractions.IFileSystem
    /// Get local folder path
    /// </summary>
    /// <param name="type">File type</param>
    /// <returns>Full path folder</returns>
    public string GetLocalFolderPath(DataTypeEnum type)
    {
      return GetLocalFilePath(type, null);
    }

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileType">File of type</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    public string GetLocalFilePath(DataTypeEnum fileType, string filename)
    {
      string folder = string.Empty;
      string ext = string.Empty;
      switch (fileType.Value)
      {
        case DataTypeEnum.DataType.Settings:
          folder = "settings";
          ext = DataTypeEnum.SETTINGS.LocalizedName;
          break;
        case DataTypeEnum.DataType.Contents:
          folder = "contents";
          ext = DataTypeEnum.CONTENTS.LocalizedName;
          break;
        default:
          folder = "temp";
          break;
      }
      string path = string.Empty;
      if (MockFileSystemStorage.UseMockFileSystem)
        path = _RootTestApp;
      else
        path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

      if (String.IsNullOrEmpty(filename))
      {
        return Path.Combine(path, folder);
      }
      return Path.Combine(path, folder, $"{filename}.{ext}");
    }

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    public void SaveFile(string path, string fileContent)
    {
      FileSystemStorage.File.WriteAllText(path, fileContent, _Encoding);
    }

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    public void SaveFileLines(string path, IEnumerable<string> fileContent)
    {
      FileSystemStorage.File.WriteAllLines(path, fileContent, _Encoding);
    }

    /// <summary>
    /// Load text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <returns>string from file</returns>
    public string LoadFile(string path)
    {
      return FileSystemStorage.File.ReadAllText(path, _Encoding);
    }

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <returns>Lines from file</returns>
    public IEnumerable<string> LoadFileLines(string path)
    {
      return FileSystemStorage.File.ReadLines(path, _Encoding);
    }

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path to file</param>
    public void DeleteFile(string path)
    {
      FileSystemStorage.File.Delete(path);
    }
  }
}
