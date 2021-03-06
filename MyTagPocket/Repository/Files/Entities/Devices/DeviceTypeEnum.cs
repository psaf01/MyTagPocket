﻿using MyTagPocket.CoreUtil;
using static MyTagPocket.Repository.Files.Entities.Devices.DeviceTypeEnum;

namespace MyTagPocket.Repository.Files.Entities.Devices
{ 
  /// <summary>
  /// Device type
  /// </summary>
  public sealed class DeviceTypeEnum : EnumBase<DeviceTypeEnum, string, DeviceType, string>
  {
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
    public static readonly DeviceTypeEnum Uwp = new DeviceTypeEnum("Uwp", DeviceType.Uwp, "uwp");
  }
}
