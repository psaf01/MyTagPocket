using System;

namespace MyTagPocket.CoreUtil.Exceptions
{
  /// <summary>
  /// Fatal error in application exception
  /// </summary>
  public class FatalErrorException : Exception
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public FatalErrorException()
    {

    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public FatalErrorException(string message): base(message)
    { 
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public FatalErrorException (string message, Exception inner) : base(message, inner)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="userMessage">User friendly message</param>
    public FatalErrorException(string message, string userMessage): base(message)
    {
      UserMessage = userMessage;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="userMessage">User friednly message</param>
    /// <param name="inner">Inner exception</param>
    public FatalErrorException(string message, string userMessage, Exception inner): base(message, inner)
    {
      UserMessage = userMessage;
    }

    /// <summary>
    /// User friendly message
    /// </summary>
    public string UserMessage { get; set; }
  }
}
