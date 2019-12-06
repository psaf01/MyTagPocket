using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Data type MyPocketType
  /// </summary>
  public sealed class DataTypeEnum
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public DataTypeEnum()
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name type of data</param>
    /// <param name="valueEnum">Data type</param>
    /// <param name="codeDataType">Code data type</param>
    private DataTypeEnum(string name, DataType valueEnum, string localizedName, string fileExtension)
    {
      Name = name;
      LocalizedName = localizedName;
      Value = valueEnum;
      FileExtension = fileExtension;
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
      User,
      /// <summary>
      /// Local Database
      /// </summary>
      Db,
      /// <summary>
      /// Local Database for audit log
      /// </summary>
      Audit
    }

    /// <summary>
    /// A unique or unclassifiable type
    /// </summary>
    public static readonly DataTypeEnum Unclassified = new DataTypeEnum("unclassified", DataType.Setting, Resources.ResourceApp.FileNameUnclassified, "mtp");

    /// <summary>
    /// Application settings
    /// </summary>
    public static readonly DataTypeEnum Setting = new DataTypeEnum("setting", DataType.Setting, Resources.ResourceApp.FileNameSetting, "cfg");

    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum Package = new DataTypeEnum("package", DataType.Package, Resources.ResourceApp.FileNamePackage,  "pck");

    /// <summary>
    /// TAG
    /// </summary>
    public static readonly DataTypeEnum Tag = new DataTypeEnum("tag", DataType.Tag, Resources.ResourceApp.FileNameTag, "tag");

    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly DataTypeEnum Theme = new DataTypeEnum("themes", DataType.Theme, Resources.ResourceApp.FileNameTheme, "thm");

    /// <summary>
    /// Compress Archive contents
    /// </summary>
    public static readonly DataTypeEnum Archive = new DataTypeEnum("archive", DataType.Archive, Resources.ResourceApp.FileNameArchive, "arc");

    /// <summary>
    /// History archive content. Information about stored individual contents in the ARC file is stored here
    /// </summary>
    public static readonly DataTypeEnum History = new DataTypeEnum("history", DataType.History, Resources.ResourceApp.FileNameHistory, "hst");

    /// <summary>
    /// Device. Information about device
    /// </summary>
    public static readonly DataTypeEnum Device = new DataTypeEnum("device", DataType.Device, Resources.ResourceApp.FileNameDevice, "dvc");

    /// <summary>
    /// User. Information about user
    /// </summary>
    public static readonly DataTypeEnum User = new DataTypeEnum("user", DataType.User, Resources.ResourceApp.FileNameUser, "usr");

    /// <summary>
    /// Local database
    /// </summary>
    public static readonly DataTypeEnum Db = new DataTypeEnum("mytagpocket", DataType.Db, Resources.ResourceApp.FileNameMainDb, "db");

    /// <summary>
    /// Local database for audit log
    /// </summary>
    public static readonly DataTypeEnum Audit = new DataTypeEnum("audit", DataType.Audit, Resources.ResourceApp.FileNameAuditDb, "db");

    #region Enum methods
    private static List<DataTypeEnum> listEnum { get; set; } = null;

    /// <summary>
    /// Name
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// Data type
    /// </summary>
    public readonly DataType Value;

    /// <summary>
    /// Localized name
    /// </summary>
    public readonly string LocalizedName;

    /// <summary>
    /// File extension
    /// </summary>
    public readonly string FileExtension;

    /// <summary>
    /// Convert enumerator to list
    /// </summary>
    /// <returns>List with enumerators</returns>
    public static List<DataTypeEnum> ToList()
    {
      if (listEnum == null)
      {
        listEnum = typeof(DataTypeEnum).GetFields().Where(x => x.IsStatic && x.IsPublic && x.FieldType == typeof(DataTypeEnum))
            .Select(x => x.GetValue(null)).OfType<DataTypeEnum>().ToList();
      }

      return listEnum;
    }

    /// <summary>
    /// Enumerator list
    /// </summary>
    /// <returns></returns>
    public static List<DataTypeEnum> Values()
    {
      return ToList();
    }

    /// <summary>
    /// Returns the enum value based on the matching Name of the enum. Case-insensitive search.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static DataTypeEnum ValueOf(string name)
    {
      return ToList().FirstOrDefault(x => string.Compare(x.Name.ToString(), name, true) == 0);
    }

    /// <summary>
    /// Base name type file name
    /// </summary>
    /// <returns></returns>
    public override String ToString()
    {
      return Name.ToString();
    }

    /// <summary>
    /// Compares based on the == method. Handles nulls gracefully.
    /// </summary>
    /// <param name="a">Object a</param>
    /// <param name="b">Object b</param>
    /// <returns></returns>
    public static bool operator !=(DataTypeEnum a, DataTypeEnum b)
    {
      return !(a?.ToString() == b?.ToString());
    }

    /// <summary>
    /// Compares based on the .Equals method. Handles nulls gracefully.
    /// </summary>
    /// <param name="a">Object a</param>
    /// <param name="b">Object b</param>
    /// <returns></returns>
    public static bool operator ==(DataTypeEnum a, DataTypeEnum b)
    {
      return a?.ToString() == b?.ToString();
    }

    /// <summary>
    /// Compares based on the .ToString() method
    /// </summary>
    /// <param name="o">Compare object</param>
    /// <returns>True: same object</returns>
    public override bool Equals(object o)
    {
      return ToString() == o?.ToString();
    }

    /// <summary>
    /// Object hash code
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return string.Format("{0}_{1}", Name, Value).GetHashCode();
    }
    #endregion Enum methods
  }
}
