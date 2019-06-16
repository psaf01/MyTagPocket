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
      None
    }

    /// <summary>
    /// A unique or unclassifiable type
    /// </summary>
    public static readonly EncryptTypeEnum NONE = new EncryptTypeEnum("NONE", EncryptType.None, "O");
  }
}
