using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File;
using System;
using System.IO.Abstractions;

namespace MyTagPocket.UWP.Library.CoreUtil
{
  /// <summary>
  /// File helper for UWP application
  /// </summary>
  public class FileHelper_UWP : FileHelperBase, IFileHelper
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public FileHelper_UWP()
    {
      FileSystemStorage = new FileSystem();
      ApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
  }
}