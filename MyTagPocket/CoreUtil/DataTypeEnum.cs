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
    public static readonly DataTypeEnum Unclassified = new DataTypeEnum("Unclassified", DataType.Settings, "mtp");
    /// <summary>
    /// Application settings
    /// </summary>
    public static readonly DataTypeEnum Settings = new DataTypeEnum("Settings", DataType.Settings, "cfg");
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum Contents = new DataTypeEnum("Contents", DataType.Contents, "mtp");

    /// <summary>
    /// TAG
    /// </summary>
    public static readonly DataTypeEnum Tag = new DataTypeEnum("Tag", DataType.Contents, "mtp");

    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum Themes = new DataTypeEnum("Themes", DataType.Themes, "thm");

    /// <summary>
    /// Compress Archive contents
    /// </summary>
    public static readonly DataTypeEnum Archive = new DataTypeEnum("Archive", DataType.Archive, "arc");

    /// <summary>
    /// History archive content. Information about stored individual contents in the ARC file is stored here
    /// </summary>
    public static readonly DataTypeEnum History = new DataTypeEnum("History", DataType.History, "hst");
  }
}
