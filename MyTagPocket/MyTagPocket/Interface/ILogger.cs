using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Interface
{
  /// <summary>
  /// Interface Logger in application
  /// </summary>
  public interface ILogger
  {
    /// <summary>
    /// Class code
    /// </summary>
    string ClassCode { get; set; }

    /// <summary>
    /// Trace
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Trace(string methodCode, string text, params object[] args);

    /// <summary>
    /// Debug
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Agruments</param>
    void Debug(string methodCode, string text, params object[] args);

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Info(string methodCode, string text, params object[] args);

    /// <summary>
    /// Warning
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Warn(string methodCode, string text, params object[] args);

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Error(string methodCode, string text, params object[] args);

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Error(Exception ex, string methodCode, string text, params object[] args);

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Fatal(string methodCode, string text, params object[] args);

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Fatal(Exception ex, string methodCode, string text, params object[] args);

    /// <summary>
    /// Audit
    /// </summary>
    /// <param name="id">Identification object (GUID)</param>
    /// <param name="text">Message</param>
    /// <param name="args">Aguments</param>
    void Audit(string id, string text, params object[] args);
  }
}