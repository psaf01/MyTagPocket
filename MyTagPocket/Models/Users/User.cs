using MyTagPocket.Models.Devices;
using System;

namespace MyTagPocket.Models.Users
{
  /// <summary>
  /// User MyTagPocket
  /// </summary>
  public class User
  {
    /// <summary>
    /// GUID user
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Identification folder GUID
    /// </summary>
    public string FolderId { get; set; }

    /// <summary>
    /// User created on device
    /// </summary>
    public Device CreatedOnDevice { get; set; }

    /// <summary>
    /// User E-mail
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Firstname
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// Lastname
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Full name for public 
    /// </summary>
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
    public string Nickname { get; set; }

    /// <summary>
    /// Use a nickname instead of a real name
    /// </summary>
    public bool UseNickname { get; set; }

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
