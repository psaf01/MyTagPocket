using NLog;
using System;

namespace MyTagPocket.CoreUtil
{

  /// <summary>
  /// Loging
  /// </summary>
  public class Log : Interface.ILogger
  {
    private Logger log;

    /// <summary>
    /// Class code
    /// </summary>
    public string ClassCode { get; set; }

    /// <summary>
    /// Instance log
    /// </summary>
    /// <param name="log"></param>
    public Log(Logger log)
    {
      this.log = log;
    }

    /// <summary>
    /// Debug
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Agruments</param>
    public void Debug(string methodCode, string text, params object[] args)
    {
      log.Debug($"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(string methodCode, string text, params object[] args)
    {
      log.Error($"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(Exception ex, string methodCode, string text, params object[] args)
    {
      log.Error(ex, $"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(string methodCode, string text, params object[] args)
    {
      log.Fatal($"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(Exception ex, string methodCode, string text, params object[] args)
    {
      log.Fatal(ex, $"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Info(string methodCode, string text, params object[] args)
    {
      log.Info($"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Trace
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Trace(string methodCode, string text, params object[] args)
    {
      log.Trace($"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Warning
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Text message</param>
    /// <param name="args">Arument</param>
    public void Warn(string methodCode, string text, params object[] args)
    {
      log.Warn($"{ClassCode} {methodCode} {text}", args);
    }

    /// <summary>
    /// Audit
    /// </summary>
    /// <param name="id">Identification object (GUID)</param>
    /// <param name="text">Message</param>
    /// <param name="args">Aguments</param>
    public void Audit(string id, string text, params object[] args)
    {
      log.Info($"{ClassCode} [0000000] {id} {string.Format(text, args)}");
    }
  }
}
