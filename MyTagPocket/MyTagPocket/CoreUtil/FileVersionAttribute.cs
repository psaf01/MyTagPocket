using System;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Atribute file version
  /// </summary>
  public class FileVersionAttribute :Attribute
  {
    private int fileVersion;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="version">Actual file version in code Entities</param>
    public FileVersionAttribute(int version)
    {
      fileVersion = version;
    }

    /// <summary>
    /// File version
    /// </summary>
    public int Version
    {
      get
      {
        return fileVersion;
      }
    }
  }
}
