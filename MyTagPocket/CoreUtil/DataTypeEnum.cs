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
      Setting,
      /// <summary>
      /// Package
      /// </summary>
      Package,
      /// <summary>
      /// TAG
      /// </summary>
      Tag,
      /// <summary>
      /// Theme application
      /// </summary>
      Theme,
      /// <summary>
      /// Compress archive content 
      /// </summary>
      Archive,
      /// <summary>
      /// History archive content. Information about stored individual contents in the ARC file is stored here
      /// </summary>
      History,
      /// <summary>
      /// Device
      /// </summary>
      Device,
      /// <summary>
      /// User
      /// </summary>
      User
    }

    /// <summary>
    /// A unique or unclassifiable type
    /// </summary>
    public static readonly DataTypeEnum Unclassified = new DataTypeEnum("Unclassified", DataType.Setting, "mtp");
    /// <summary>
    /// Application settings
    /// </summary>
    public static readonly DataTypeEnum Setting = new DataTypeEnum("Setting", DataType.Setting, "cfg");
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum Package = new DataTypeEnum("Package", DataType.Package, "pck");

    /// <summary>
    /// TAG
    /// </summary>
    public static readonly DataTypeEnum Tag = new DataTypeEnum("Tag", DataType.Tag, "tag");

    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum Theme = new DataTypeEnum("Themes", DataType.Theme, "thm");

    /// <summary>
    /// Compress Archive contents
    /// </summary>
    public static readonly DataTypeEnum Archive = new DataTypeEnum("Archive", DataType.Archive, "arc");

    /// <summary>
    /// History archive content. Information about stored individual contents in the ARC file is stored here
    /// </summary>
    public static readonly DataTypeEnum History = new DataTypeEnum("History", DataType.History, "hst");

    /// <summary>
    /// Device. Information about device
    /// </summary>
    public static readonly DataTypeEnum Device = new DataTypeEnum("Device", DataType.Device, "dvc");

    /// <summary>
    /// User. Information about user
    /// </summary>
    public static readonly DataTypeEnum User = new DataTypeEnum("User", DataType.User, "usr");


  }
}
