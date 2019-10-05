using static MyTagPocket.CoreUtil.EncryptTypeEnum;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Encrypt type
  /// </summary>
  public sealed class EncryptTypeEnum : EnumBase<EncryptTypeEnum, string, EncryptType, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">Encrypt type</param>
    /// <param name="codeEncrypt">Code encrypt</param>
    private EncryptTypeEnum(string name, EncryptType valueEnum, string codeEncrypt) : base(name, valueEnum, codeEncrypt)
    {
    }

    /// <summary>
    /// Data type
    /// </summary>
    public enum EncryptType
    {
      /// <summary>
      /// None encrypt
      /// </summary>
      None,
      /// <summary>
      /// HASH SHA 512
      /// </summary>
      Sha512,
      /// <summary>
      /// AES
      /// </summary>
      Aes
    }

    /// <summary>
    /// A unique or unclassifiable type
    /// </summary>
    public static readonly EncryptTypeEnum None = new EncryptTypeEnum("NONE", EncryptType.None, "O");

    /// <summary>
    /// SHA512 hash
    /// </summary>
    public static readonly EncryptTypeEnum Sha512 = new EncryptTypeEnum("SHA512", EncryptType.Sha512, "1");

    /// <summary>
    /// AES 
    /// </summary>
    public static readonly EncryptTypeEnum Aes = new EncryptTypeEnum("AES", EncryptType.Aes, "2");
  }
}
