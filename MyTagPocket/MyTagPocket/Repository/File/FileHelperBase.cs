using MyTagPocket.CoreUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace MyTagPocket.Repository.File
{
  /// <summary>
  /// Base file helper for all systems
  /// </summary>
  public class FileHelperBase
  {
    #region Private Properties
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
    #endregion Private Properties

    #region Public Properties
    /// <summary>
    /// File system on device
    /// </summary>
    public IFileSystem FileSystemStorage { get => _FileSystemStorage; set => _FileSystemStorage = value; }

    /// <summary>
    /// Root path for application file data
    /// </summary>
    public string ApplicationDataPath { get => _ApplicationDataPath; set => _ApplicationDataPath = value; }

    #endregion Public Properties

    #region Public Method
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
    /// <param name="fileTypeValue">Idnetification file type</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    public virtual string GetLocalFilePath(string fileTypeValue, string filename)
    {
      var fileType = DataTypeEnum.ValueOf(fileTypeValue);
      return GetLocalFilePath(fileType, filename);
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
        return _FileSystemStorage.Path.Combine(_ApplicationDataPath, folder);
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
      _FileSystemStorage.File.WriteAllText(path, fileContent, _Encoding);
    }

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    public virtual void SaveFileLines(string path, IEnumerable<string> fileContent)
    {
      _FileSystemStorage.File.WriteAllLines(path, fileContent, _Encoding);
    }

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    public virtual void SaveAppendToFile(string path, string content)
    {
      _FileSystemStorage.File.AppendAllText(path, content, _Encoding);
    }

    /// <summary>
    /// Add binary data to file 
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Content</param>
    public virtual void SaveAppendToFile(string path, byte[] content)
    {
      using (var FS = _FileSystemStorage.FileStream.Create(path, _FileSystemStorage.File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write))
      {
        FS.Write(content, 0, content.Length);
        FS.Close();
      }
    }

    /// <summary>
    /// Check exists the file
    /// </summary>
    /// <param name="path">Full path to the file</param>
    /// <returns></returns>
    public virtual bool FileExists(string path)
    {
      return FileSystemStorage.File.Exists(path);
    }

    /// <summary>
    /// Check exists the folder
    /// </summary>
    /// <param name="path">Full path to the folder</param>
    /// <returns></returns>
    public virtual bool FolderExists(string path)
    {
      return FileSystemStorage.Directory.Exists(path);
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
      return _FileSystemStorage.File.ReadLines(path, _Encoding);
    }

    /// <summary>
    /// Load contet from file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="startPosition">Position from where to start reading</param>
    /// <param name="lengthContent">Length of content to be read</param>
    /// <returns></returns>
    public virtual byte[] LoadContentFromFile(string path, int startPosition, int lengthContent)
    {
      byte[] result;
      using (BinaryReader b = new BinaryReader(_FileSystemStorage.File.Open(path, FileMode.Open)))
      {
        // Seek to our required position.
        b.BaseStream.Seek(startPosition, SeekOrigin.Begin);

        // Read the next 2000 bytes.
        result = b.ReadBytes(lengthContent);
      }

      return result;
    }

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">Full path to file</param>
    public virtual void DeleteFile(string path)
    {
      FileSystemStorage.File.Delete(path);
    }
    #endregion Public Metdhod

    #region Private Method

    #endregion Private Method
  }
}
