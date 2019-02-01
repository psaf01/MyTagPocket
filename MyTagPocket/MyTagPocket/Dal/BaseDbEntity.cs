using SQLite;
using System;

namespace MyTagPocket.Dal
{
  /// <summary>
  /// Base Entity for database layer SQLite
  /// </summary>
  public abstract class BaseDbEntity
  {
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog();

    /// <summary>
    /// Object locker for secure operations over databases
    /// </summary>
    static object locker = new object();

    /// <summary>
    /// Name table in database
    /// </summary>
    protected string TableName;

    /// <summary>
    /// SQL database connection
    /// </summary>
    SQLiteConnection db;
    private string v;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyTagPocket.Storage"/> MyTagPocket. 
    /// if the database doesn't exist, it will create the database and all the tables.
    /// </summary>
    /// <param name='path'>
    /// Path.
    /// </param>
    public BaseDbEntity(SQLiteConnection conn, string tableName)
    {
      db = conn;
      TableName = tableName;
      // create the tables
      //database.CreateTable<TodoItem>();
    }

    /// <summary>
    /// Check version table and Entity. If diferent than actual will be upgrade to new version.
    /// </summary>
    public void CheckVersionTable()
    {
      try
      {
        using (db)
        {
          string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name ='{TableName}';";
          SQLiteCommand cmd = db.CreateCommand(query);
          var item = db.Query<object>(query);
          if (item.Count > 0)
            return;
          Log.Trace($"CheckVersionTable [{TableName}] not exists");
          CreateTable();
        }
      }
      catch (Exception ex)
      {
        Log.Fatal($"CheckVersionTable [{TableName}] Exception [{ex.Message }]");
      }
    }

    /// <summary>
    /// Create table
    /// </summary>
    protected abstract void CreateTable(); 
  }
}
