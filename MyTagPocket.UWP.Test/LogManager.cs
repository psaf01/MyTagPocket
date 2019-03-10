﻿using MyTagPocket.Interface;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyTagPocket.UWP.Test.LogManager))]
namespace MyTagPocket.UWP.Test
{

  /// <summary>
  /// Log Manager
  /// </summary>
  public class LogManager : MyTagPocket.Interface.ILogManager
  {
    public LogManager()
    {
      var config = new LoggingConfiguration();
      //Debuger
#if DEBUG
      var debugerTarget = new DebuggerTarget("Debugger")
      {
        Layout = @"${date:format=HH\:mm\:ss} | ${pad:padding=5:inner=${level:uppercase=true}} | ${message} | ${exception}"
      };
      config.AddTarget(debugerTarget);
#endif
      //File
      //string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      string  path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

      var fileInfoTarget = new FileTarget("FileInfo")
      {
        FileName = Path.Combine(path, "Log-${shortdate}.log"),
        Layout = "${longdate} ${pad:padding=5:inner=${level:uppercase=true}} ${message}  ${exception}",
        MaxArchiveFiles = 5,
        ArchiveEvery = FileArchivePeriod.Day,
      };
      var fileErrorTarget = new FileTarget("FileError")
      {
        FileName = Path.Combine(path, "LogError-${shortdate}.log"),
        Layout = "${longdate} ${pad:padding=5:inner=${level:uppercase=true}} ${message}  ${exception}",
        MaxArchiveFiles = 5,
        ArchiveEvery = FileArchivePeriod.Day,
      };

      var fileTraceTarget = new FileTarget("FileTrace")
      {
        FileName = Path.Combine(path, "LogTrace-${shortdate}.log"),
        Layout = "${longdate} ${pad:padding=5:inner=${level:uppercase=true}} ${message}  ${exception}",
        MaxArchiveFiles = 5,
        ArchiveEvery = FileArchivePeriod.Day,
      };
      //fileTarget.FileName = Path.Combine(folder, "Log.txt");
      config.AddTarget("FileInfo", fileInfoTarget);
      config.AddTarget("FileError", fileErrorTarget);
      config.AddTarget("FileTrace", fileTraceTarget);
     
      //File Info rule
      var fileInfoRule = new LoggingRule("*", LogLevel.Info, fileInfoTarget);
      config.LoggingRules.Add(fileInfoRule);
      //File Error rule
      var fileErrorRule = new LoggingRule("*", LogLevel.Error, fileErrorTarget);
      config.LoggingRules.Add(fileErrorRule);
      //File Trace rule
      var fileTraceRule = new LoggingRule("*", LogLevel.Trace, fileTraceTarget);
      config.LoggingRules.Add(fileTraceRule);
      //Debuger rule
#if DEBUG
      config.AddRuleForAllLevels(debugerTarget);
#endif
      NLog.LogManager.Configuration = config;
    }

    /// <summary>
    ///  GetLog instance
    /// </summary>
    /// <param name="classCode">Class code for localization</param>
    /// <param name="callerFilePath"></param>
    /// <returns></returns>
    public Interface.ILogger GetLog(string classCode, [System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
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
