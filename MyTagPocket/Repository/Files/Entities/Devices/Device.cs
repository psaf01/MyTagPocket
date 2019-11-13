using MyTagPocket.CoreUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Repository.Files.Entities.Devices
{
  public class Device : FileEntityBase<Device>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Device() : base(DataTypeEnum.Device, null, EncryptTypeEnum.Aes, version: 1)
    { }

    /// <summary>
    /// Device name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Generat hash code of device 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() ^ Name.GetHashCode();
    }
  }
}
