using NLog;
using System;

namespace MyTagPocket
{

  /// <summary>
  /// Loging
  /// </summary>
  public class Log : ILogger
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
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Agruments</param>
    public void Debug(string codeMethod, string text, params object[] args)
    {
      log.Debug($"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(string codeMethod, string text, params object[] args)
    {
      log.Error($"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(Exception ex, string codeMethod, string text, params object[] args)
    {
      log.Error(ex, $"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(string codeMethod, string text, params object[] args)
    {
      log.Fatal($"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(Exception ex, string codeMethod, string text, params object[] args)
    {
      log.Fatal(ex, $"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Info(string codeMethod, string text, params object[] args)
    {
      log.Info($"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Trace
    /// </summary>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Trace(string codeMethod, string text, params object[] args)
    {
      log.Trace($"{ClassCode} {codeMethod} {text}", args);
    }

    /// <summary>
    /// Warning
    /// </summary>
    /// <param name="codeMethod">Code method for localization</param>
    /// <param name="text">Text message</param>
    /// <param name="args">Arument</param>
    public void Warn(string codeMethod, string text, params object[] args)
    {
      log.Warn($"{ClassCode} {codeMethod} {text}", args);
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
