using MyTagPocket.CoreUtil;
using MyTagPocket.Dal.Entities;
using MyTagPocket.Dal.Upgrade.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Dal.Upgrade
{
  /// <summary>
  /// Upgrade database contens
  /// </summary>
  public class UpgradeDbContents : IUpgradeDbContents
  {
    const string classCode = "[1000500]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Object locker for secure operations over databases
    /// </summary>
    static readonly object locker = new object();

    /// <summary>
    /// SQL database connection
    /// </summary>
    SQLiteConnection db;

    #region Constructor
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="conn"></param>
    public UpgradeDbContents(SQLiteConnection conn)
    {
      db = conn;
    }
    #endregion Constructor

    #region Public method
    /// <summary>
    /// Check and if necessary upgrade database
    /// </summary>
    public void CheckAndUpgrade()
    {
      const string methodCode = "[1000501]";
      Log.Trace(methodCode, "Start Check And Upgrade Contents");
      CheckAndUpgrade(new TableVersion());
      Log.Trace(methodCode, "End Check And Upgrade Contents");
    }

    /// <summary>
    /// Remove / drop the specified table from the DB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public bool DropTable<T>() where T : class
    {
      const string methodCode = "[1000502]";
      try
      {
        var error = db.DropTable<T>();
        var exists = (error != 0);
        Log.Trace(methodCode, $"Contents Drop table [{typeof(T).Name}]");
        return exists;
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"Contents Drop table [{typeof(T).Name}] Exception [{ex.Message}]");
        return false;
      }

    }

    /// <summary>
    /// Check exists table in database
    /// </summary>
    /// <typeparam name="T">Class of Table</typeparam>
    /// <returns>True = exists</returns>
    public bool IsExistsTable<T>() where T : class
    {
      bool exists = IsTypeExistst("table", typeof(T).Name);
      return exists;
    }

    /// <summary>
    /// Create table
    /// </summary>
    /// <typeparam name="T">Class of Table</typeparam>
    /// <returns></returns>
    public void CreateTable<T>() where T : class
    {
      const string methodCode = "[1000503]";
      try
      {
        if (IsExistsTable<T>())
        {
          return;
        }

        var error = db.CreateTable<T>();
        var exists = (error == 0);
        Log.Trace(methodCode, $"Contents Create table [{typeof(T).Name}]");
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"Contents Cant create table [{typeof(T).Name}] Exception [{ex.Message}]");
        throw new Exception($"Contents Cant create table [{typeof(T).Name}] ");
      }
    }

    /// <summary>
    /// Generic method to determine is an object type exists within the DB
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool IsTypeExistst(string type, string name)
    {
      SQLiteCommand command = db.CreateCommand("SELECT COUNT(1) FROM SQLITE_MASTER WHERE TYPE = @TYPE AND NAME = @NAME");
      command.Bind("@TYPE", type);
      command.Bind("@NAME", name);

      int result = command.ExecuteScalar<int>();

      return (result > 0);
    }

    /// <summary>
    /// Check TableVersion
    /// </summary>
    public void CheckAndUpgrade(TableVersion table)
    {
      const string methodCode = "[1000504]";
      int actualVersion = 1;
      try
      {
        CreateTable<Entities.TableVersion>();
        table.ActualVersion = actualVersion;
        table.TableName = typeof(TableVersion).Name;
        db.Insert(table);
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"Contents Cant CheckAndUpgrade [{typeof(TableVersion).Name}] Exception [{ex.Message}]", ex);
        throw new Exception($"Contents Cant CheckAndUpgrade [{typeof(TableVersion).Name}]");
      }
    }

    /// <summary>
    /// Get version table from Entity class
    /// </summary>
    /// <param name="t">Entity table class</param>
    /// <returns>Version actual table entity</returns>
    public int GetVersionTableFromEntity(Type t)
    {
      const string methodCode = "[1000505]";
      // Get instance of the attribute.
      TableVersionAttribute MyAttribute =
          (TableVersionAttribute)Attribute.GetCustomAttribute(t, typeof(TableVersionAttribute));

      if (MyAttribute == null)
      {
        Log.Fatal(methodCode, $"Contents Not definition TableVersionAttribute in {t.Name}");
        return 0;
      }
      else
      {
        return MyAttribute.Version;
      }
    }
    #endregion Public method

    #region Private method

    #endregion Private method
  }
}