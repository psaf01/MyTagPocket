using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Dal
{

 
  /// <summary>
  /// Version of each table of project MyTagPocket in database
  /// </summary>
  public class TableVersion : BaseDbEntity
  {
    /// <summary>
    /// Name table in database
    /// </summary>
    private const string tableName = "TableVersion";

    public TableVersion(SQLiteConnection conn) : base(conn, tableName)
    {

    }

    /// <summary>
    /// Create table in database
    /// </summary>
    protected override void CreateTable()
    {
      throw new NotImplementedException();
    }
  }
}
