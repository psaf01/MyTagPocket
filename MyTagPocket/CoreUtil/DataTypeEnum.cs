using static MyTagPocket.CoreUtil.DataTypeEnum;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Data type MyPocketType
  /// </summary>
  public sealed class DataTypeEnum : EnumBase<DataTypeEnum, string, DataType, string>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">Data type</param>
    /// <param name="codeDataType">Code data type</param>
    private DataTypeEnum(string name, DataType valueEnum, string codeDataType) : base(name, valueEnum, codeDataType)
    {
    }

    /// <summary>
    /// Data type
    /// </summary>
    public enum DataType
    {
      /// <summary>
      /// A unique or unclassifiable type
      /// </summary>
      Unclassified,
      /// <summary>
      /// Application settings
      /// </summary>
      Settings,
      /// <summary>
      /// Contents notes
      /// </summary>
      Contents,
      /// <summary>
      /// TAG
      /// </summary>
      Tag,
      /// <summary>
      /// Theme application
      /// </summary>
      Themes,
      /// <summary>
      /// Compress archive content 
      /// </summary>
      Archive,
      /// <summary>
      /// History archive content. Information about stored individual contents in the ARC file is stored here
      /// </summary>
      History
    }

    /// <summary>
    /// A unique or unclassifiable type
    /// </summary>
    public static readonly DataTypeEnum UNCLASSIFIED = new DataTypeEnum("UNCLASSIFIED", DataType.Settings, "mtp");
    /// <summary>
    /// Application settings
    /// </summary>
    public static readonly DataTypeEnum SETTINGS = new DataTypeEnum("SETTINGS", DataType.Settings, "cfg");
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum CONTENTS = new DataTypeEnum("CONTENTS", DataType.Contents, "mtp");

    /// <summary>
    /// TAG
    /// </summary>
    public static readonly DataTypeEnum TAG = new DataTypeEnum("TAG", DataType.Contents, "mtp");

    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum THEMES = new DataTypeEnum("THEMES", DataType.Themes, "thm");

    /// <summary>
    /// Compress Archive contents
    /// </summary>
    public static readonly DataTypeEnum ARCHIVE = new DataTypeEnum("ARCHIVE", DataType.Archive, "arc");

    /// <summary>
    /// History archive content. Information about stored individual contents in the ARC file is stored here
    /// </summary>
    public static readonly DataTypeEnum HISTORY = new DataTypeEnum("HISTORY", DataType.History, "hst");
  }
}
