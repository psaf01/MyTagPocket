using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.UWP.CoreUtil;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace MyTagPocket.UWP.CoreUtil
{
  /// <summary>
  /// File helper for UWP application
  /// </summary>
  public class FileHelper :IFileHelper
  {

    public FileHelper()
    {
      FileSystemStorage = new FileSystem();
    }

    public IFileSystem FileSystemStorage { get;set;}

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
        default:
          folder = "temp";
          break;
      }
      string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

      if (String.IsNullOrEmpty(filename))
      {
        return Path.Combine(path, folder);
      }
      return Path.Combine(path, folder, $"{filename}{ext}");
    }
      /// <summary>
      /// Get full path for application database
      /// </summary>
      /// <returns></returns>
      public string GetPathAppDb()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      return Path.Combine(path, "MyTagPocket.db3");
    }

    /// <summary>
    /// Get full path for content database
    /// </summary>
    /// <returns></returns>
    public string GetPathContentDb()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      return Path.Combine(path, GetPathContent(), "ContentList.db3");
    }

    /// <summary>
    /// Get path for Contents files
    /// </summary>
    /// <returns></returns>
    public string GetPathContent()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      return Path.Combine(path, "Contents");
    }

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    /// <returns>True = save ok</returns>
    public async Task SaveFile(string path, string fileContent)
    {
      FileSystemStorage.File.WriteAllText(path, fileContent);
    }

    /// <summary>
    /// Load text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    /// <returns>True = load ok</returns>
    public async Task<string> LoadFile(string path)
    {
      return FileSystemStorage.File.ReadAllText(path);
    }

    public async Task DeleteFile(string path)
    {
      FileSystemStorage.File.Delete(path);
    }
  }
}
