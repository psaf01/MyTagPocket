using System;

namespace MyTagPocket.CoreUtil.Exceptions
{
  /// <summary>
  /// Fatal error in application exception
  /// </summary>
  public class FileSystemException : Exception
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public FileSystemException()
    {

    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public FileSystemException(string message): base(message)
    { 
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public FileSystemException(string message, Exception inner) : base(message, inner)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="userMessage">User friendly message</param>
    public FileSystemException(string message, string userMessage): base(message)
    {
      UserMessage = userMessage;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="userMessage">User friednly message</param>
    /// <param name="inner">Inner exception</param>
    public FileSystemException(string message, string userMessage, Exception inner): base(message, inner)
    {
      UserMessage = userMessage;
    }

    /// <summary>
    /// User friendly message
    /// </summary>
    public string UserMessage { get; set; }
  }
}
