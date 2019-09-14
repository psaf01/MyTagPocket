using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File;
using System;
using System.IO.Abstractions;

namespace MyTagPocket.UWP.CoreUtil
{
  /// <summary>
  /// File helper for UWP application
  /// </summary>
  public class FileHelper_UWP : FileHelperBase, IFileHelper
  {
    /// <summary>
    /// Encoding file
    /// </summary>
    //private System.Text.Encoding _Encoding = System.Text.Encoding.UTF8;

    const string classCode = "[1002900]";
    /// <summary>
    /// Logger instance
    /// </summary>
    private ILogger Log;
   

    /// <summary>
    /// Constructor
    /// </summary>
    public FileHelper_UWP(ILogManager logManager)
    {
      Log = logManager.GetLog(classCode);
      ///var service = Container.Resolve<IService>()
      FileSystemStorage = new FileSystem();
      ApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
  }
}