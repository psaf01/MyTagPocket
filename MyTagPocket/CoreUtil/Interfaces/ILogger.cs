using System;

namespace MyTagPocket.CoreUtil.Interfaces
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
    /// Informatin
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Info(string methodCode, string text, params object[] args);

    /// <summary>
    /// Informatin
    /// </summary>
    /// <param name="methodCode">Code method for localization</param>
    /// <param name="type">Data type</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Info(string methodCode, DataTypeEnum type, string text, params object[] args);

    /// <summary>
    /// Audit
    /// </summary>
    /// <param name="auditCode">Audit code</param>
    /// <param name="type">Data type</param>
    /// <param name="args">Values</param>
    void Audit(string auditCode, DataTypeEnum type, params object[] values);

    /// <summary>
    /// Debug
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="type">Data type</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Debug(string methodCode, string text, params object[] args);

    /// <summary>
    /// Error
    /// </summary>
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Error(string methodCode, string text, params object[] args);

    /// <summary>
    /// Error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Error(Exception ex, string methodCode, string text, params object[] args);

    /// <summary>
    /// Fatal error
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Fatal(Exception ex, string methodCode, string text, params object[] args);
    /// <summary>
    /// Trace
    /// </summary>
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Trace(string methodCode, string text, params object[] args);

    /// <summary>
    /// Warning
    /// </summary>
    /// <param name="methodCode">Code method for localization in source</param>
    /// <param name="text">Message</param>
    /// <param name="args">Arguments</param>
    void Warn(string methodCode, string text, params object[] args);
  }
}