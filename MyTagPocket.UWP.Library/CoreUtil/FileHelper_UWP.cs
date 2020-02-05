using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Files;
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
      if (string.IsNullOrEmpty(AppGlobal.Folders.LocalRootFolder))
      {
        AppGlobal.Folders.LocalRootFolder = ApplicationDataPath;
      }
    }
  }
}