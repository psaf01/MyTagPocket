using Newtonsoft.Json;

namespace MyTagPocket.Repository.Files.Entities.Users
{
  /// <summary>
  /// Basic information about user
  /// </summary>
  public class UserBasicInfo
  {
    /// <summary>
    /// Identification entity
    /// </summary>
    [JsonProperty("id")]
    public string EntityId { get; set; }

    /// <summary>
    /// User E-mail
    /// </summary>
    [JsonProperty("e")]
    public string Email { get; set; }

    /// <summary>
    /// Nickname, alias
    /// </summary>
    [JsonProperty("f")]
    public string FullName { get; set; }
  }
}
