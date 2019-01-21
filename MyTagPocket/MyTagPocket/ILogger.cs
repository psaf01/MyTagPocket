using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket
{
  /// <summary>
  /// Interface Logger in application
  /// </summary>
  public interface ILogger
  {
    /// <summary>
    /// Trace
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Trace(string text, params object[] args);

    /// <summary>
    /// Debug
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Agruments</param>
    void Debug(string text, params object[] args);

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Info(string text, params object[] args);

    /// <summary>
    /// Warning
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Warn(string text, params object[] args);

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Error(string text, params object[] args);

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Fatal(string text, params object[] args);

    /// <summary>
    /// Audit
    /// </summary>
    /// <param name="id">Identification object (GUID)</param>
    /// <param name="text">Message</param>
    /// <param name="args">Aguments</param>
    void Audit(string id, string text, params object[] args);
  }
}