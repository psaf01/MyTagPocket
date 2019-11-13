using MyTagPocket.CoreUtil;
using Newtonsoft.Json;

namespace MyTagPocket.Repository.Files.Entities.Users
{
  /// <summary>
  /// Information about user
  /// </summary>
  public class User : FileEntityBase<User>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public User() : base(DataTypeEnum.User, null, EncryptTypeEnum.Aes, 1)
    { }

    /// <summary>
    /// User E-mail
    /// </summary>
    [JsonProperty("e")]
    public string Email { get; set; }

    /// <summary>
    /// Firstname
    /// </summary>
    [JsonProperty("f")]
    public string Firstname { get; set; }

    /// <summary>
    /// Lastname
    /// </summary>
    [JsonProperty("l")]
    public string Lastname { get; set; }

    /// <summary>
    /// Full name for public 
    /// </summary>
    [JsonProperty("fn")]
    public string FullName
    {
      get
      {
        if (UseNickname)
          return Nickname;

        return @"{Firstname} {Lastname}";
      }
    }

    /// <summary>
    /// Nickname, alias
    /// </summary>
    [JsonProperty("n")]
    public string Nickname { get; set; }

    /// <summary>
    /// Use a nickname instead of a real name
    /// </summary>
    public bool UseNickname { get; set; }

    /// <summary>
    /// Generat hash code of user 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() ^ FullName.GetHashCode() ^ Email.GetHashCode();
    }
  }
}
