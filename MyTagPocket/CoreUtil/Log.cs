using LiteDB;
using MyTagPocket.CoreUtil.Exceptions;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Audit.Entities;
using MyTagPocket.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTagPocket.CoreUtil
{

  /// <summary>
  /// Loging
  /// </summary>
  public class Log : Interfaces.ILogger
  {
    private NLog.Logger log;

    private IAuditRepository auditLog;

    /// <summary>
    /// Class code
    /// </summary>
    public string ClassCode { get; set; }

    /// <summary>
    /// Instance log
    /// </summary>
    /// <param name="log"></param>
    public Log(NLog.Logger log, IAuditRepository auditLogHelper)
    {
      this.log = log;
      auditLog = auditLogHelper;
    }

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
    private void InitializeAuditLog()
    {
      try
      {
        auditLog.InitializeAuditLogAsync();
      }
      catch (ErrorException ex)
      {
        Error("", ex.Message);
      }
      catch (Exception ex)
      {
        Error("", ex.Message);
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
    public async Task AuditAsync(string auditCode, DataTypeEnum type, string deviceGuid, string userGuid)
    {
      await AuditAsync(auditCode, type, deviceGuid, userGuid, null);
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
    public async Task AuditAsync(string auditCode, DataTypeEnum type, string deviceGuid, string userGuid, Dictionary<string, string> values)
    {
      Audit a = new Audit();
      a.Code = auditCode;
      a.CreatedWhen = DateTimeOffset.Now;
      a.UserGuid = userGuid;
      a.DeviceGuid = deviceGuid;
      a.DataType = type.Name;
      a.Parameters = values;
      Info("AUDIT", $"{auditCode} {type.LocalizedName}");
      await auditLog.SaveAsync(a);
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
