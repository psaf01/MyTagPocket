using Newtonsoft.Json;

namespace MyTagPocket.Repository.Files.Entities.Devices
{
  /// <summary>
  /// Basic information about device
  /// </summary>
  public class DeviceBasicInfo
  {
    /// <summary>
    /// Identification entity
    /// </summary>
    [JsonProperty("Id")]
    public string EntityId { get; set; }

    /// <summary>
    /// Device name
    /// </summary>
    [JsonProperty("n")]
    public string Name { get; set; }
  }
}
