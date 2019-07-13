using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File;
using MyTagPocket.UWP.Test.CoreUtil;
using System;
using System.IO.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace MyTagPocket.UWP.Test.CoreUtil
{
  /// <summary>
  /// File helper for UWP application
  /// </summary>
  public class FileHelper : FileHelperBase, IFileHelper
  {
    //const string classCode = "[9001200]";
    //public static Interface.ILogger Log = DependencyService.Get<Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Encoding file
    /// </summary>
    private System.Text.Encoding _Encoding = System.Text.Encoding.UTF8;

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
      {
        FileSystemStorage = MockFileSystemStorage.MockFileSystem;
        ApplicationDataPath = _RootTestApp;
      }
      else
      {
        FileSystemStorage = new FileSystem();
        ApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      }
    }
  }
}
