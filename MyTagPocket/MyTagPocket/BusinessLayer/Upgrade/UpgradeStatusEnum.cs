using MyTagPocket.CoreUtil;
using static MyTagPocket.BusinessLayer.Upgrade.UpgradeStatusEnum;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Upgrade staus enumerator
  /// </summary>
  public sealed class UpgradeStatusEnum : EnumBase<UpgradeStatusEnum, string, UpgradeStatus, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name upgrade status</param>
    /// <param name="valueEnum">Upgrade status type</param>
    /// <param name="localizationName">Localization upgrade status name</param>
    private UpgradeStatusEnum(string name, UpgradeStatus valueEnum, string localizationName) : base(name, valueEnum, localizationName)
    {
    }

    /// <summary>
    /// Update progress enumerator
    /// /// </summary>
    public enum UpgradeStatus
    {
      NotStart,
      Stop,
      Progress,
      EndSuccess,
      EndError
    }

    public static readonly UpgradeStatusEnum NOTSTART = new UpgradeStatusEnum("NOTSTART", UpgradeStatus.NotStart, Resources.ResourceApp.UpgradeStatusNotStart);
    public static readonly UpgradeStatusEnum STOP = new UpgradeStatusEnum("STOP", UpgradeStatus.Stop, Resources.ResourceApp.UpgradeStatusStop);
    public static readonly UpgradeStatusEnum PROGRESS = new UpgradeStatusEnum("PROGRESS", UpgradeStatus.Progress, Resources.ResourceApp.UpgradeStatusProgress);
    public static readonly UpgradeStatusEnum ENDSUCCESS = new UpgradeStatusEnum("ENDSUCCESS", UpgradeStatus.EndSuccess, Resources.ResourceApp.UpgradeStatusEndSucces);
    public static readonly UpgradeStatusEnum ENDERROR = new UpgradeStatusEnum("ENDERROR", UpgradeStatus.EndError, Resources.ResourceApp.UpgradeStatusEndError);
  }
}
