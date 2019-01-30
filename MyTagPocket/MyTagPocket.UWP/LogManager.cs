using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyTagPocket.UWP.LogManager))]
namespace MyTagPocket.UWP
{

  /// <summary>
  /// Log Manager
  /// </summary>
  public class LogManager : ILogManager
  {
    public LogManager()
    {
      var config = new LoggingConfiguration();
      //Debuger
      var debugerTarget = new DebuggerTarget("Debugger")
      {
        Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}"
      };
      config.AddTarget(debugerTarget);

      //Console
      var consoleTarget = new ColoredConsoleTarget("Console")
      {
        Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}"
      };
      config.AddTarget("console", consoleTarget);
      //Console rule
      //var consoleRule = new LoggingRule("*", LogLevel.Info, consoleTarget);
      //config.LoggingRules.Add(consoleRule);

      //File
      //string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
      string file = Path.Combine(folder.Path, "Log.txt");
      var fileTarget = new FileTarget("File")
      {
        FileName = file,
        Layout = "${longdate} ${level} ${message}  ${exception}"
      };
      
      //fileTarget.FileName = Path.Combine(folder, "Log.txt");
      config.AddTarget("file", fileTarget);
      //File rule
      //var fileRule = new LoggingRule("*", LogLevel.Info, fileTarget);
      //config.LoggingRules.Add(fileRule);
      //Rule
      config.AddRuleForAllLevels(consoleTarget);
      config.AddRuleForAllLevels(fileTarget);
      config.AddRuleForAllLevels(debugerTarget);

      NLog.LogManager.Configuration = config;
    }

    /// <summary>
    ///  GetLog instance
    /// </summary>
    /// <param name="callerFilePath"></param>
    /// <returns></returns>
    public ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
    {
      string fileName = callerFilePath;

      if (fileName.Contains("/"))
      {

      }

      //config.AddRuleForAllLevels(consoleTarget);
      var logger = NLog.LogManager.GetLogger(fileName);
      return new Log(logger);
    }
  }
}
