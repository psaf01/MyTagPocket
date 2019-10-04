using System;

namespace MyTagPocket.CoreUtil.Exceptions
{
  /// <summary>
  /// Error in application exception
  /// </summary>
  public class ErrorException : Exception
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public ErrorException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public ErrorException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public ErrorException(string message, Exception inner) : base(message, inner)
    { }

  }
}
