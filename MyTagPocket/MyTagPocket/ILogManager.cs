namespace MyTagPocket
{

  /// <summary>
  /// Inteface Log Manager
  /// </summary>
  public interface ILogManager
  {
    /// <summary>
    /// Get Log 
    /// </summary>
    /// <param name="callerFilePath">Pat to log file</param>
    /// <returns>Logger</returns>
    ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath]string callerFilePath = "");
  }
}
