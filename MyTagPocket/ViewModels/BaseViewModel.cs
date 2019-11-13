using MyTagPocket.CoreUtil.Interfaces;
using Prism.Mvvm;

namespace MyTagPocket.ViewModels
{
  /// <summary>
  /// Base view model
  /// </summary>
  public class BaseViewModel : BindableBase
  {
    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// Constructor for base view model
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="classCode">Class identification</param>
    public BaseViewModel(ILogManager logManager, string classCode)
    {
      Log = logManager.GetLog(classCode);
    }
  }
}
