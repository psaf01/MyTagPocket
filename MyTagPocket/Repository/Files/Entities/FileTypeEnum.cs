using MyTagPocket.CoreUtil;
using static MyTagPocket.Repository.Files.FileTypeEnum;

namespace MyTagPocket.Repository.Files
{
  /// <summary>
  /// File type
  /// </summary>
  public sealed class FileTypeEnum : EnumBase<FileTypeEnum, string, FileType, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">File type</param>
    /// <param name="codeEncrypt">Code file</param>
    private FileTypeEnum(string name, FileType valueEnum, string codeFile) : base(name, valueEnum, codeFile)
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
    public static readonly FileTypeEnum Txt = new FileTypeEnum("Txt", FileType.Txt, "txt");
  }
}
