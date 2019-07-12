using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;
using Xamarin.Forms;

namespace MyTagPocket.Repository.File
{
  /// <summary>
  /// Base file helper for all systems
  /// </summary>
  public class FileHelperBase 
  {
    const string classCode = "[1002700]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Root path for application file data
    /// </summary>
    private string _ApplicationDataPath;

    /// <summary>
    /// File system on device
    /// </summary>
    private IFileSystem _FileSystemStorage;

    /// <summary>
    /// Encoding file
    /// </summary>
    private System.Text.Encoding _Encoding = System.Text.Encoding.UTF8;

    /// <summary>
    /// File system on device
    /// </summary>
    public IFileSystem FileSystemStorage {get => _FileSystemStorage; set =>  _FileSystemStorage = value;}

    /// <summary>
    /// Root path for application file data
    /// </summary>
    public string ApplicationDataPath { get => _ApplicationDataPath; set => _ApplicationDataPath = value; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fileSystem">File system storage</param>
    /// <param name="applicationDataPath">Roor application data path</param>
    public FileHelperBase()
    {
    }

    /// <summary>Abstractions.IFileSystem
    /// Get local folder path
    /// </summary>
    /// <param name="type">File type</param>
    /// <returns>Full path folder</returns>
    public virtual string GetLocalFolderPath(DataTypeEnum type)
    {
      return GetLocalFilePath(type, null);
    }

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileType">File of type</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    public virtual string GetLocalFilePath(DataTypeEnum fileType, string filename)
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


      if (String.IsNullOrEmpty(filename))
      {
        return  _FileSystemStorage.Path.Combine(_ApplicationDataPath,folder);
      }

      return _FileSystemStorage.Path.Combine(_ApplicationDataPath, folder, $"{filename}.{ext}");
    }

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    public virtual void SaveFile(string path, string fileContent)
    {
      FileSystemStorage.File.WriteAllText(path, fileContent, _Encoding);
    }

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    public virtual void SaveFileLines(string path, IEnumerable<string> fileContent)
    {
      FileSystemStorage.File.WriteAllLines(path, fileContent, _Encoding);
    }

    /// <summary>
    /// Load text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <returns>string from file</returns>
    public virtual string LoadFile(string path)
    {
      return FileSystemStorage.File.ReadAllText(path, _Encoding);
    }

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <returns>Lines from file</returns>
    public virtual IEnumerable<string> LoadFileLines(string path)
    {
      return FileSystemStorage.File.ReadLines(path, _Encoding);
    }

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path to file</param>
    public virtual void DeleteFile(string path)
    {
      FileSystemStorage.File.Delete(path);
    }
  }
}
