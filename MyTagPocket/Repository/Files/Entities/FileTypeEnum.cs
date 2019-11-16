using MyTagPocket.CoreUtil;
using static MyTagPocket.Repository.Files.DeviceTypeEnum;

namespace MyTagPocket.Repository.Files
{
  /// <summary>
  /// File type
  /// </summary>
  public sealed class DeviceTypeEnum : EnumBase<DeviceTypeEnum, string, FileType, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">File type</param>
    /// <param name="codeEncrypt">Code file</param>
    private DeviceTypeEnum(string name, FileType valueEnum, string codeFile) : base(name, valueEnum, codeFile)
    {
    }

    /// <summary>
    /// Data type
    /// </summary>
    public enum FileType
    {
      /// <summary>
      /// Plain text file
      /// </summary>
      Txt,

      /// <summary>
      /// Html
      /// </summary>
      Html
    }

    /// <summary>
    /// A unique or unclassifiable type
    /// </summary>
    public static readonly DeviceTypeEnum Txt = new DeviceTypeEnum("Txt", FileType.Txt, "txt");
  }
}
