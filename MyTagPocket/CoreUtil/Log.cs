using LiteDB;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Models.Audits;
using MyTagPocket.Models.Devices;
using MyTagPocket.Models.Users;
using MyTagPocket.Repository.Dal.Entities.App;
using NLog;
using System;

namespace MyTagPocket.CoreUtil
{

  /// <summary>
  /// Loging
  /// </summary>
  public class Log : Interfaces.ILogger
  {
    private NLog.Logger log;

    private IFileHelper fileHelper;

    /// <summary>
    /// Class code
    /// </summary>
    public string ClassCode { get; set; }

    /// <summary>
    /// Instance log
    /// </summary>
    /// <param name="log"></param>
    public Log(NLog.Logger log, IFileHelper fileHelperInstance)
    {
      this.log = log;
      fileHelper = fileHelperInstance;
    }

    /// <summary>
    /// File helper
    /// </summary>
    public IFileHelper FileHelper { get; set; }
    /// <summary>
    /// Initialize logger for first time
    /// </summary>
    public void InitializeLog()
    {
      InitializeAuditLog();
    }

    /// <summary>
    /// Initialize audit log database
    /// </summary>
    /// <param name="fileHelper">File helper</param>
    private void InitializeAuditLog()
    {
      var dbPath = fileHelper.GetLocalFilePath(DataTypeEnum.Audit, null, null);
      if (fileHelper.FileExists(dbPath))
        return;

      using (var db = new LiteDatabase(dbPath))
      {
        if (db.Engine.UserVersion == 0)
        {
          Audit a = new Audit();
          a.Code = AuditCodes.InitAuditDb;
          a.CreatedWhen = DateTimeOffset.Now;
          a.UserGuid = AppGlobal.UserSystem.UserGuid;
          a.DeviceGuid = AppGlobal.Device.DeviceGuid;
          a.DataType = DataTypeEnum.Audit;
          a.Parameters = null;

          db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.Code), false);
          db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.CreatedWhen), false);
          db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.UserGuid), false);
          db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.DeviceGuid), false);
          db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.DataType), false);
          var col = db.GetCollection<Audit>();
          if (!col.Upsert(a))
            Error("C00000M01", "Cant insert first audit log");
        }

      }
    }

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Info(string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Info(text, args);
    }

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="type">Data type</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Info(string methodCode, DataTypeEnum type, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Info(text, args);
    }

    /// <summary>
    /// Audit
    /// </summary>
    /// <param name="fileHelper">File helper</param>
    /// <param name="auditCode">Audit code</param>
    /// <param name="type">Data type</param>
    /// <param name="deviceGuid">GUID device</param>
    /// <param name="userGuid">GUID user</param>
    /// <param name="values">Values parameters</param>
    public void Audit(string auditCode, DataTypeEnum type, string deviceGuid, string userGuid, params string[] values)
    {
      var dbPath = fileHelper.GetLocalFilePath(DataTypeEnum.Audit, null, null);

      using (var db = new LiteDatabase(dbPath))
      {
        Audit a = new Audit();
        a.Code = auditCode;
        a.CreatedWhen = DateTimeOffset.Now;
        a.UserGuid = userGuid;
        a.DeviceGuid = deviceGuid;
        a.DataType = type;
        a.Parameters = values;
      }
    }

    /// <summary>
    /// Debug
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Debug(string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Debug(text, args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Error(text, args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(Exception ex, string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Error(ex, text, args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Fatal(text, args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(Exception ex, string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Fatal(ex, text, args);
    }

    /// <summary>
    /// Trace
    /// </summary>
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Trace(string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Trace(text, args);
    }

    /// <summary>
    /// Warning
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Warn(string methodCode, string text, params object[] args)
    {
      log.WithProperty("MethodCode", ClassCode + methodCode).Warn(text, args);
    }
  }
}
