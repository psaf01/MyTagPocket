using System;

namespace MyTagPocket.Models.Devices
{
  /// <summary>
  /// Device
  /// </summary>
  public class Device
  {
    /// <summary>
    /// GUID device
    /// </summary>
    public string DeviceId { get; set; }

    /// <summary>
    /// Identification folder GUID
    /// </summary>
    public string FolderId { get; set; }

    /// <summary>
    /// Device type
    /// </summary>
    public DeviceTypeEnum DeviceType { get; set; }

    /// <summary>
    /// Device name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Entity created when
    /// </summary>
    public DateTimeOffset CreatedWhen { get; set; }

    /// <summary>
    /// Entity updated when
    /// </summary>
    public DateTimeOffset UpdatedWhen { get; set; }
  }
}
