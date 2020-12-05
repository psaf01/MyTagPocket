using LiteDB;
using System;
using System.IO;

namespace MyTagPocket.DbStorage
{
  /// <summary>
  /// DbLite helper
  /// </summary>
  public class DbLiteFileHelper : IDbLiteHelper
  {
    private string fullPathToDatabase;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fullPath">Full path to database</param>
    public DbLiteFileHelper(string fullPath)
    {
      if (string.IsNullOrWhiteSpace(fullPath))
        throw new Exception("Full path to database is null or empty.");

      fullPathToDatabase = fullPath;
    }

    /// <summary>
    /// Full path to LiteDb database
    /// </summary>
    public string FullPathToDatabase { get => fullPathToDatabase; }

    /// <summary>
    /// Open LiteDb in memmory
    /// </summary>
    /// <returns>Lite db</returns>
    public LiteDatabase OpenDB()
    {
      return new LiteDatabase(fullPathToDatabase);
    }
  }
}
