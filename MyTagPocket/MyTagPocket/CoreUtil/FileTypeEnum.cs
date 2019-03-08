using System;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// File type MyPocketType
  /// </summary>
  public sealed class FileTypeEnum
  {
    #region This code never needs to change.
    //private static readonly Dictionary<string, FileType> strInstance = new Dictionary<string, FileType>();
    //private static readonly Dictionary<int, FileType> intInstance = new Dictionary<int, FileType>();

    private readonly string _name;
    public readonly FileType Value;
    public readonly string Ext;

    /// <summary>
    /// Define file type enum
    /// </summary>
    /// <param name="fileType">Type file enum</param>
    /// <param name="name">Name type file</param>
    /// <param name="ext">Extension file type</param>
    private FileTypeEnum(FileType fileType, String name, String ext)
    {
      this._name = name;
      this.Value = fileType;
      this.Ext= ext;
    }

    /// <summary>
    /// Base name type file name
    /// </summary>
    /// <returns></returns>
    public override String ToString()
    {
      return _name;
    }

    /// <summary>
    /// Equals obejct
    /// </summary>
    /// <param name="obj">Check object</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
        return false;

      FileTypeEnum fooItem = obj as FileTypeEnum;

      return fooItem.Value == this.Value;
    }

    /// <summary>
    /// Object hash code
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return string.Format("{0}_{1}_{2}", _name, Value, Ext).GetHashCode();
    }

    public static bool operator ==(FileTypeEnum a, FileTypeEnum b)
    {
      return a.Value == b.Value;
    }
    public static bool operator !=(FileTypeEnum a, FileTypeEnum b)
    {
      return a.Value != b.Value;
    }
    #endregion
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
    public static readonly FileTypeEnum SETTINGS= new FileTypeEnum(FileType.Settings, "SETTINGS", "cfg");
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly FileTypeEnum CONTENTS = new FileTypeEnum(FileType.Settings, "CONTENTS", "data");
    
    /// <summary>
    /// Contents notes
    /// </summary>
    public static readonly FileTypeEnum THEMES = new FileTypeEnum(FileType.Themes, "THEMES", "cfg");

  }
}
