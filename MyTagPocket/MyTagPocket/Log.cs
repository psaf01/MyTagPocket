using NLog;

namespace MyTagPocket
{

  /// <summary>
  /// Loging
  /// </summary>
  public class Log : ILogger
  {
    private Logger log;
    
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
    /// <param name="text">Message</param>
    /// <param name="args">Agruments</param>
    public void Debug(string text, params object[] args)
    {
      log.Debug(text, args);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Error(string text, params object[] args)
    {
      log.Error(text, args);
    }

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Fatal(string text, params object[] args)
    {
      log.Fatal(text, args);
    }

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Info(string text, params object[] args)
    {
      log.Info(text, args);
    }

    /// <summary>
    /// Trace
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    public void Trace(string text, params object[] args)
    {
      log.Trace(text, args);
    }

    public void Warn(string text, params object[] args)
    {
      log.Warn(text, args);
    }

    /// <summary>
    /// Audit
    /// </summary>
    /// <param name="id">Identification object (GUID)</param>
    /// <param name="text">Message</param>
    /// <param name="args">Aguments</param>
    public void Audit(string id, string text, params object[] args)
    {
      //TODO: create log audit db
    }
  }
}
