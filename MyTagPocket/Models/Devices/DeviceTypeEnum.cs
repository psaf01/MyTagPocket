using MyTagPocket.CoreUtil;
using static MyTagPocket.Models.Devices.DeviceTypeEnum;

namespace MyTagPocket.Models.Devices
{ 
  /// <summary>
  /// Device type
  /// </summary>
  public sealed class DeviceTypeEnum : EnumBase<DeviceTypeEnum, string, DeviceType, string>
  {

    public DeviceTypeEnum() : base("Unknown", DeviceType.Unknown, "Unknown")
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">Device type</param>
    /// <param name="codeEncrypt">Code file</param>
    private DeviceTypeEnum(string name, DeviceType valueEnum, string codeFile) : base(name, valueEnum, codeFile)
    {
    }

    /// <summary>
    /// Data type
    /// </summary>
    public enum DeviceType
    {
      /// <summary>
      /// Universal Windows Platform 
      /// </summary>
      Uwp,

      /// <summary>
      /// Unknown
      /// </summary>
      Unknown
    }

    /// <summary>
    ///  Universal Windows Platform 
    /// </summary>
    public static readonly DeviceTypeEnum Uknown = new DeviceTypeEnum("Unknown", DeviceType.Unknown, Resources.ResourceApp.TypeDeviceUnknown);

    /// <summary>
    ///  Universal Windows Platform 
    /// </summary>
    public static readonly DeviceTypeEnum Uwp = new DeviceTypeEnum("Uwp", DeviceType.Uwp, Resources.ResourceApp.TypeDeviceUwp);
  }
}
