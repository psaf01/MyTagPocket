using MyTagPocket.Interface;

namespace MyTagPocket.Interface
{
  /// <summary>
  /// Inteface Log Manager
  /// </summary>
  public interface ILogManager
  {
    /// <summary>
    /// Get Log 
    /// </summary>
    /// <param name="classCode">Class code for localization</param>
    /// <param name="callerFilePath">Pat to log file</param>
    /// <returns>Logger</returns>
    ILogger GetLog(string classCode, [System.Runtime.CompilerServices.CallerFilePath]string callerFilePath = "");
  }
}
