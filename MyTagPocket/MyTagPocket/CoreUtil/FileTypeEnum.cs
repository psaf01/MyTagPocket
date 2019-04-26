using System;
using static MyTagPocket.CoreUtil.FileTypeEnum;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// File type MyPocketType
  /// </summary>
  public sealed class FileTypeEnum : EnumBase<FileTypeEnum, string, FileType, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of file</param>
    /// <param name="valueEnum">File type</param>
    /// <param name="fileExtension">fileExtension</param>
    private FileTypeEnum(string name, FileType valueEnum, string fileExtension) : base(name, valueEnum, fileExtension)
    {
    }

    public enum FileType
    {
      /// <summary>
      /// Application settings
      /// </summary>
      Settings,
      /// <summary>
      /// Contents notes
      /// </summary>
      Contents,
      /// <summary>
      /// Theme application
      /// </summary>
      Themes
    }

    /// <summary>
    /// Application settings
    /// </summary>
    public static readonly FileTypeEnum SETTINGS= new FileTypeEnum("SETTINGS", FileType.Settings, "cfg");
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly FileTypeEnum CONTENTS = new FileTypeEnum("CONTENTS", FileType.Contents, "data");
    
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly FileTypeEnum THEMES = new FileTypeEnum("THEMES", FileType.Themes, "thm");
  }
}
