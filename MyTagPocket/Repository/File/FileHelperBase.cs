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

    /// <summary>
    /// Root path for application file data
    /// </summary>
    private string applicationDataPath;

    /// <summary>
    /// File system on device
    /// </summary>
    private IFileSystem fileSystemStorage;

    /// <summary>
    /// Encoding file
    /// </summary>
    private System.Text.Encoding encoding = System.Text.Encoding.UTF8;
    #endregion Private Properties

    #region Public Properties
    /// <summary>
    /// File system on device
    /// </summary>
    public IFileSystem FileSystemStorage { get => fileSystemStorage; set => fileSystemStorage = value; }

    /// <summary>
    /// Root path for application file data
    /// </summary>
    public string ApplicationDataPath { get => applicationDataPath; set => applicationDataPath = value; }

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
      return GetLocalFilePath(type, null, null);
    }

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileTypeValue">Idnetification file type</param>
    /// <param name="subFolder">Generic subfolder</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    public virtual string GetLocalFilePath(string fileTypeValue, string subFolder, string filename)
    {
      var fileType = DataTypeEnum.ValueOf(fileTypeValue);
      return GetLocalFilePath(fileType, subFolder, filename);
    }

    /// <summary>
    /// Get local file path
    /// </summary>
    /// <param name="fileType">File of type</param>
    /// <param name="subFolder">Generic subfolder</param>
    /// <param name="filename">File name</param>
    /// <returns>Full path file. If File name null or empty return Full path folder</returns>
    public virtual string GetLocalFilePath(DataTypeEnum fileType, string subFolder, string filename)
    {
      string ext = string.Empty;
      string folder;
      switch (fileType.Value)
      {
        case DataTypeEnum.DataType.Setting:
          folder = "settings";
          ext = DataTypeEnum.Setting.LocalizedName;
          break;
        case DataTypeEnum.DataType.Package:
          folder = "contents";
          ext = DataTypeEnum.Package.LocalizedName;
          break;
        case DataTypeEnum.DataType.Device:
          folder = "devices";
          ext = DataTypeEnum.Device.LocalizedName;
          break;
        case DataTypeEnum.DataType.User:
          folder = "users";
          ext = DataTypeEnum.User.LocalizedName;
          break;
        default:
          folder = "temp";
          break;
      }

      var folderFile =  fileSystemStorage.Path.Combine(applicationDataPath, folder);
      
      if (string.IsNullOrEmpty(filename))
        return folderFile;

      if (string.IsNullOrEmpty(subFolder))
        return fileSystemStorage.Path.Combine(folderFile, $"{filename}.{ext}");

      return fileSystemStorage.Path.Combine(folderFile, subFolder, $"{filename}.{ext}");
    }

    /// <summary>
    /// Save text file
    /// </summary>
    /// <param name="path">Full path file</param>
    /// <param name="fileContent">Content file</param>
    public virtual void SaveFile(string path, string fileContent)
    {
      var folder = fileSystemStorage.Path.GetDirectoryName(path);
      if (!fileSystemStorage.Directory.Exists(folder))
        fileSystemStorage.Directory.CreateDirectory(folder);

      fileSystemStorage.File.WriteAllText(path, fileContent, encoding);
    }

    /// <summary>
    /// Save all lines to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="fileContent">Collection of strings</param>
    public virtual void SaveFileLines(string path, IEnumerable<string> fileContent)
    {
      fileSystemStorage.File.WriteAllLines(path, fileContent, encoding);
    }

    /// <summary>
    /// Add text to file
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Text</param>
    public virtual void SaveAppendToFile(string path, string content)
    {
      fileSystemStorage.File.AppendAllText(path, content, encoding);
    }

    /// <summary>
    /// Add binary data to file 
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Content</param>
    public virtual void SaveAppendToFile(string path, byte[] content)
    {
      using (var FS = fileSystemStorage.FileStream.Create(path, fileSystemStorage.File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write))
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
      return FileSystemStorage.File.ReadAllText(path, encoding);
    }

    /// <summary>
    /// Load all lines from file tu collection
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <returns>Lines from file</returns>
    public virtual IEnumerable<string> LoadFileLines(string path)
    {
      return fileSystemStorage.File.ReadLines(path, encoding);
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
      using (BinaryReader b = new BinaryReader(fileSystemStorage.File.Open(path, FileMode.Open)))
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
