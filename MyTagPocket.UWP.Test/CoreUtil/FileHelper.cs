using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.UWP.Test.CoreUtil;
using System;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace MyTagPocket.UWP.Test.CoreUtil
{
  /// <summary>
  /// File helper for UWP application
  /// </summary>
  public class FileHelper :IFileHelper
  {

    /// <summary>
    /// Get local folder path
    /// </summary>
    /// <param name="type">File type</param>
    /// <returns>Full path folder</returns>
    public string GetLocalFolderPath(FileTypeEnum type)
    {
      return GetLocalFilePath(type, null);
    }

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileType">FileType</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    public string GetLocalFilePath(FileTypeEnum fileType, string filename)
    {
      string folder = string.Empty;
      string ext = string.Empty;
      switch (fileType.Value)
      {
        case FileTypeEnum.FileType.Settings:
          folder = "settings";
          ext = "." + FileTypeEnum.SETTINGS.Ext;
          break;
        case FileTypeEnum.FileType.Contents:
          folder = "contents";
          ext = "." + FileTypeEnum.CONTENTS.Ext;
          break;
        case FileTypeEnum.FileType.Themes:
          folder = "themes";
          ext = "." + FileTypeEnum.THEMES.Ext;
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
  }
}
