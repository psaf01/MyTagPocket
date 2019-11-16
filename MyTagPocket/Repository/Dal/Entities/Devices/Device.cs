using MyTagPocket.Repository.Dal.Interface;

namespace MyTagPocket.Repository.Dal.Entities.Devices
{
  /// <summary>
  /// Device
  /// </summary>
  public class Device : DalBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Device(): base(nameCollectionEntity: "devices")
    {
    }

    /// <summary>
    /// GUID device
    /// </summary>
    public string DeviceId { get; set; }

    /// <summary>
    /// Identification folder GUID
    /// </summary>
    public string FolderId { get; set; }

    /// <summary>
    /// Device name
    /// </summary>
    public string Name { get; set; }
  }
}
