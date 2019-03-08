using MyTagPocket.Dal.Entities;
using MyTagPocket.Dal.Repository.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Dal.Repository
{
  public class TableVersionRepository : GenericRepository<TableVersion>, ITableVersionRepository
  {
    const string classCode = "[1000300]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    SQLiteConnection db;
    /// <summary>
    /// Version Entitty
    /// </summary>
    const int versionTableEntity = 1;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Database connection</param>
    public TableVersionRepository(SQLiteConnection conn): base(conn)
    {
      db = conn;
    }

    /// <summary>
    /// Get version table
    /// </summary>
    /// <param name="tableName">Table Name</param>
    /// <returns>0 = Definition table not exists</returns>
    public int GetVersion(string tableName)
    {
      const string methodCode = "[1000301]";
      try
      {
        var ver = db.Table<TableVersion>().Where(x => x.TableName == tableName).FirstOrDefault();
        if(ver == null)
        {
          Log.Error(methodCode, $"GetVersion not found definition table [{tableName}]");
          return 0;
        }
        return ver.ActualVersion;
      }
      catch(Exception ex)
      {
        Log.Fatal(methodCode, $"GetVersion table [{tableName}] exception [{ex.Message}]");
        throw ex;
      }
    }

    /// <summary>
    /// Get version actual table
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <returns></returns>
    public int GetVersion<T>()
    {
      return GetVersion(typeof(T).Name);
    }

    /// <summary>
    /// Actual version table of Entities
    /// </summary>
    public override int VersionTableEntity
    {
      get
      {
        return versionTableEntity;
      }
    }
  }
}
