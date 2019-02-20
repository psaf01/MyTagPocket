using System;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Atribute Table version
  /// </summary>
  public class TableVersionAttribute :Attribute
  {
    private int tableVersion;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="version">Actual table version in code Entities</param>
    public TableVersionAttribute(int version)
    {
      tableVersion = version;
    }

    /// <summary>
    /// Version table
    /// </summary>
    public int Version
    {
      get
      {
        return tableVersion;
      }
    }
  }
}
