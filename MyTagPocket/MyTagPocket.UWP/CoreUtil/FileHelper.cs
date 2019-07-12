using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File;
using MyTagPocket.UWP.CoreUtil;
using System;
using System.Collections.Generic;
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

    /// <summary>
    /// Constructor
    /// </summary>
    public FileHelper()
    {
        FileSystemStorage = new FileSystem();
        ApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
  }
}