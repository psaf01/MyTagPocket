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

    /// <summary>
    /// Class code
    /// </summary>
    public string ClassCode { get; set; }

    /// <summary>
    /// Instance log
    /// </summary>
    /// <param name="log"></param>
    public Log(NLog.Logger log)
    {
      this.log = log;
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
    /// <param name="auditCode">Audit code</param>
    /// <param name="type">Data type</param>
    /// <param name="args">Values</param>
    public void Audit(string auditCode, DataTypeEnum type, params object[] values)
    {
      
      //log.Info($"{ClassCode} [0000000] {id} {string.Format(text, args)}");
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
