using static MyTagPocket.CoreUtil.ProcessStatusEnum;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Process staus enumerator
  /// </summary>
  public sealed class ProcessStatusEnum : EnumBase<ProcessStatusEnum, string, ProcessStatus, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name process status</param>
    /// <param name="valueEnum">Process status type</param>
    /// <param name="localizationName">Localization process name</param>
    private ProcessStatusEnum(string name, ProcessStatus valueEnum, string localizationName) : base(name, valueEnum, localizationName)
    {
    }

    /// <summary>
    /// Status process
    /// </summary>
    public enum ProcessStatus
    {
      Idle,
      Runnig,
      Error,
      Paused,
    }

    public static readonly ProcessStatusEnum IDLE = new ProcessStatusEnum("IDLE", ProcessStatus.Idle, Resources.ResourceApp.ProcessIdle);
    public static readonly ProcessStatusEnum RUNNING = new ProcessStatusEnum("RUNNING", ProcessStatus.Runnig, Resources.ResourceApp.ProcessRunning);
    public static readonly ProcessStatusEnum ERROR = new ProcessStatusEnum("ERROR", ProcessStatus.Error, Resources.ResourceApp.ProcessError);
    public static readonly ProcessStatusEnum PAUSED = new ProcessStatusEnum("PAUSED", ProcessStatus.Paused, Resources.ResourceApp.ProcessPaused);
  }
}
