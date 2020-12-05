using LiteDB;
using System.IO;

namespace MyTagPocket.DbStorage
{
  /// <summary>
  /// DbLite helper
  /// </summary>
  public class DbLiteMemmoryHelper : IDbLiteHelper
  {
    private static MemoryStream memoryDb;

    /// <summary>
    /// Open LiteDb in memmory
    /// </summary>
    /// <returns>Lite db</returns>
    public LiteDatabase OpenDB()
    {
      if (memoryDb == null)
        memoryDb = new MemoryStream();

      return new LiteDatabase(memoryDb);
    }

    /// <summary>
    /// Full path to LiteDb database
    /// </summary>
    public string FullPathToDatabase { get => null; }
  }
}
