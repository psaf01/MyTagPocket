using LiteDB;

namespace MyTagPocket.DbStorage
{
  /// <summary>
  /// DAL helper for DbLite
  /// </summary>
  public interface IDbLiteHelper
  {
    /// <summary>
    /// Full path to LiteDb database
    /// </summary>
    string FullPathToDatabase { get; }

    /// <summary>
    /// Open DbLite in memmory
    /// </summary>
    /// <returns></returns>
    LiteDatabase OpenDB();
  }
}
