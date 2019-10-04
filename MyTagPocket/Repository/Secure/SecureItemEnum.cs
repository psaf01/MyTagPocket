using MyTagPocket.CoreUtil;
using static MyTagPocket.Repository.Secure.SecureItemEnum;

namespace MyTagPocket.Repository.Secure
{
  /// <summary>
  /// Item names used in secure storage
  /// </summary>

  public sealed class SecureItemEnum : EnumBase<SecureItemEnum, string, SecureItemType, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of secure type</param>
    /// <param name="valueEnum">Secure type</param>
    /// <param name="codeSecureType">Code secure type</param>
    private SecureItemEnum(string name, SecureItemType valueEnum, string codeSecureType) : base(name, valueEnum, codeSecureType)
    {
    }

    /// <summary>
    /// Secure item type
    /// </summary>
    public enum SecureItemType
    {
      /// <summary>
      /// None encrypt
      /// </summary>
      GlobalPassword
    }

    /// <summary>
    /// Global password
    /// </summary>
    public static readonly SecureItemEnum GlobalPassword = new SecureItemEnum("MTPGLOBALPASSWORD", SecureItemType.GlobalPassword, "GPWD");
  }
}
