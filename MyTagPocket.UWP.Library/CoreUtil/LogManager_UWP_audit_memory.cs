using LiteDB;
using MyTagPocket.CoreUtil;
using MyTagPocket.Repository;
using MyTagPocket.Repository.Interfaces;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Seq;
using NLog.Targets.Wrappers;
using System.IO;

namespace MyTagPocket.UWP.Library.CoreUtil
{
  /// <summary>
  /// Log Manager for OS UWP and log audit to memory
  /// </summary>
  public class LogManager_UWP_audit_memory : MyTagPocket.CoreUtil.Interfaces.ILogManager
  {
    
    /// <summary>
    /// Constructor
    /// </summary>
    public LogManager_UWP_audit_memory()
    {
      var config = NLog.LogManager.Configuration;
      if (config == null)
        config = new LoggingConfiguration();
      //Debuger
#if DEBUG
      Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;

      var debugerTarget = new DebuggerTarget("FileTrace")
      {
        Layout = @"${shortdate} | ${pad:padding=5:inner=${level:uppercase=true}} | ${gdc:item=device} | ${event-properties:MethodCode} | ${message} | ${exception}"
      };

      config.AddTarget(debugerTarget);

      var fileTraceTarget = new FileTarget("FileTrace")
      {
        FileName = Path.Combine(folder.Path, @"log", "Trace-${shortdate}.txt"),
        Layout = "${longdate} ${pad:padding=5:inner=${level:uppercase=true}} ${gdc:item=device} ${gdc:item=user} ${event-properties:MethodCode} ${message}  ${exception}",
        MaxArchiveFiles = 5,
        ArchiveEvery = FileArchivePeriod.Day,
      };
      config.AddTarget(fileTraceTarget);
      config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, fileTraceTarget));

      var deviceProperty = new SeqPropertyItem()
      {
        Name = "Device",
        Value = "${gdc:item=device}",
        As = "device"
      };
      var userProperty = new SeqPropertyItem()
      {
        Name = "User",
        Value = "${gdc:item=user}",
        As = "user"
      };

      var methodCodeProperty = new SeqPropertyItem()
      {
        Name = "MethodCode",
        Value = "${event-properties:MethodCode} ",
        As = "methodCode"
      };
      var seqSubTarget = new SeqTarget()
      {
        ServerUrl = "http://localhost:5341",
        Name = "Seq",
        ApiKey = ""
      };
      seqSubTarget.Properties.Add(deviceProperty);
      seqSubTarget.Properties.Add(userProperty);
      seqSubTarget.Properties.Add(methodCodeProperty);

      var seqTarget = new BufferingTargetWrapper(seqSubTarget, 1000, 2000);
      seqTarget.Name = "seq";
      config.AddTarget(seqTarget);
      config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, seqTarget));
      NLog.GlobalDiagnosticsContext.Set("device", "TESTPC");

#endif
      /*
      //File
      //string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
      var fileInfoTarget = new FileTarget("FileInfo")
      {
        FileName = Path.Combine(folder.Path, "Log-${shortdate}.txt"),
        Layout = "${longdate} ${pad:padding=5:inner=${level:uppercase=true}} ${message}  ${exception}",
        MaxArchiveFiles = 5,
        ArchiveEvery = FileArchivePeriod.Day,
      };
      var fileErrorTarget = new FileTarget("FileError")
      {
        FileName = Path.Combine(folder.Path, "LogError-${shortdate}.txt"),
        Layout = "${longdate} ${pad:padding=5:inner=${level:uppercase=true}} ${message}  ${exception}",
        MaxArchiveFiles = 5,
        ArchiveEvery = FileArchivePeriod.Day,
      };

      var fileTraceTarget = new FileTarget("FileTrace")
      {
        FileName = Path.Combine(folder.Path, "LogTrace-${shortdate}.txt"),
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
      */
      NLog.LogManager.Configuration = config;

      AuditLogger = new AuditRepository(new DalAuditHelper_UWP_memory());
    }

    /// <summary>
    /// Get audti log instance
    /// </summary>
    public IAuditRepository AuditLogger { get; }
    /// <summary>
    ///  GetLog instance
    /// </summary>
    /// <param name="classCode">Class code for localization</param>
    /// <param name="callerFilePath"></param>
    /// <returns></returns>
    public MyTagPocket.CoreUtil.Interfaces.ILogger GetLog(string classCode, [System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
    {
      string fileName = callerFilePath;

      if (fileName.Contains("/"))
      {

      }

      //config.AddRuleForAllLevels(consoleTarget);
      var logger = LogManager.GetLogger(fileName);
      return new Log(logger, AuditLogger) { ClassCode = classCode };
    }

    /// <summary>
    /// Flush buffer
    /// </summary>
    public void FlushBuffer()
    {
      NLog.LogManager.Flush();
    }
  }
}
