using MyTagPocket.Dal.Entities;
using MyTagPocket.Dal.Upgrade.Interface;
using MyTagPocket.CoreUtil;
using SQLite;
using System;
using Xamarin.Forms;
using MyTagPocket.CoreUtil.Interface;

namespace MyTagPocket.Dal.Upgrade
{
  /// <summary>
  /// Upgrade DB
  /// </summary>
  public class UpgradeDb : IUpgradeDbBase,IUpgradeDb
  {
    const string classCode = "[1000400]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Object locker for secure operations over databases
    /// </summary>
    static readonly object locker = new object();

    /// <summary>
    /// SQL database connection
    /// </summary>
    private SQLiteConnection _Db;

    #region Constructor
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fileHelper">File helper for acces file storage</param>
    public UpgradeDb()
    {
      _Db = new SQLiteConnection(DependencyService.Get<IFileHelper>().GetPathAppDb());
    }
    #endregion Constructor

    #region Public method
    /// <summary>
    /// Check and if necessary upgrade database
    /// </summary>
    public void CheckAndUpgrade()
    {
      const string methodCode = "[1000401]";
      Log.Trace(methodCode, "Start Check And Upgrade application database");

      CheckAndUpgradeTableVersion();
      Log.Trace(methodCode, "End Check And Upgrade application database");
    }

    /// <summary>
    /// Remove / drop the specified table from the DB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public bool DropTable<T>() where T : class
    {
      const string methodCode = "[1000402]";
      try
      {
        var error = _Db.DropTable<T>();
        var exists = (error != 0);
        Log.Trace(methodCode, $"Drop table [{typeof(T).Name}]");
        return exists;
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"Drop table [{typeof(T).Name}] Exception [{ex.Message}]");
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
      const string methodCode = "[1000403]";
      try
      {
        if (IsExistsTable<T>())
        {
          return;
        }

        var error = _Db.CreateTable<T>();
        var exists = (error == 0);
        Log.Trace(methodCode, $"Create table [{typeof(T).Name}]");
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"Cant create table [{typeof(T).Name}] Exception [{ex.Message}]");
        throw new Exception($"Cant create table [{typeof(T).Name}] ");
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
      SQLiteCommand command = _Db.CreateCommand("SELECT COUNT(1) FROM SQLITE_MASTER WHERE TYPE = @TYPE AND NAME = @NAME");
      command.Bind("@TYPE", type);
      command.Bind("@NAME", name);

      int result = command.ExecuteScalar<int>();

      return (result > 0);
    }

    /// <summary>
    /// Check TableVersion
    /// </summary>
    public void CheckAndUpgradeTableVersion()
    {
      const string methodCode = "[1000404]";
      int actualVersion = 1;
      try
      {
        CreateTable<Entities.TableVersion>();
        TableVersion table = new TableVersion
        {
          ActualVersion = actualVersion,
          TableName = typeof(TableVersion).Name
        };
        _Db.Insert(table);
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, $"Cant CheckAndUpgrade [{typeof(TableVersion).Name}] Exception [{ex.Message}]", ex);
        throw new Exception($"Cant CheckAndUpgrade [{typeof(TableVersion).Name}]");
      }
    }

    /// <summary>
    /// Get version table from Entity class
    /// </summary>
    /// <param name="t">Entity table class</param>
    /// <returns>Version actual table entity</returns>
    public int GetVersionTableFromEntity(Type t)
    {
      const string methodCode = "[1000405]";
      // Get instance of the attribute.
      TableVersionAttribute MyAttribute =
          (TableVersionAttribute)Attribute.GetCustomAttribute(t, typeof(TableVersionAttribute));

      if (MyAttribute == null)
      {
        Log.Fatal(methodCode, $"Not definition TableVersionAttribute in {t.Name}");
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

    #region Public properties

    #endregion PUblic properties
  }
}