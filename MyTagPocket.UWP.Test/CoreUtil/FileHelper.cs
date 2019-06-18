using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.UWP.Test.CoreUtil;
using System;
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
      FileSystemStorage = MockFileSystemStorage.MockFileSystem;
    }

    /// <summary>
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
    /// <param name="fileType">FileType</param>
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
          //ext = "." + FileTypeEnum.SETTINGS.Ext;
          break;
        case DataTypeEnum.DataType.Contents:
          folder = "contents";
          //ext = "." + FileTypeEnum.CONTENTS.Ext;
          break;
        case DataTypeEnum.DataType.Themes:
          folder = "themes";
          //ext = "." + FileTypeEnum.THEMES.Ext;
          break;
        default:
          folder = "temp";
          break;
      }

      if (String.IsNullOrEmpty(filename))
      {
        return Path.Combine(_RootTestApp, folder);
      }
      return Path.Combine(_RootTestApp, folder, $"{filename}{ext}");
    }
    /// <summary>
    /// Get full path for application database
    /// </summary>
    /// <returns></returns>
    public string GetPathAppDb()
    {
      return Path.Combine(_RootTestApp, "MyTagPocket.db3");
    }

    /// <summary>
    /// Get full path for content database
    /// </summary>
    /// <returns></returns>
    public string GetPathContentDb()
    {
      return Path.Combine(_RootTestApp, GetPathContent(), "ContentList.db3");
    }

    /// <summary>
    /// Get path for Contents files
    /// </summary>
    /// <returns></returns>
    public string GetPathContent()
    {
      return Path.Combine(_RootTestApp, "Contents");
    }

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    /// <returns>True = save ok</returns>
    public async Task SaveFile(string path, string fileContent)
    {
      await Task.Run(() =>
      {
        FileSystemStorage.File.WriteAllText(path, fileContent);
      });
    }

    /// <summary>
    /// Load file from Mock file system
    /// </summary>
    /// <param name="path">Full path</param>
    /// <param name="fileContent">Return text file content</param>
    /// <returns>True = load OK</returns>
    public async Task<string> LoadFile(string path)
    {
      string result = null;
      await Task.Run(() =>
      {
        if (MockFileSystemStorage.MockFileSystem.FileExists(path))
        {
          result = MockFileSystemStorage.MockFileSystem.File.ReadAllText(path);
        }
      });
      return result;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public async Task DeleteFile(string path)
    {
      await Task.Run(() =>
      {
        if (MockFileSystemStorage.MockFileSystem.FileExists(path))
        {
          MockFileSystemStorage.MockFileSystem.File.Delete(path);
        }
      });
    }
  }
}
