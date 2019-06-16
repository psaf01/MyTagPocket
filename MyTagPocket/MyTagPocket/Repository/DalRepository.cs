using MyTagPocket.Repository.Dal.Interface;
using MyTagPocket.Repository.Interface;
using SQLite;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// Database layer repository
  /// </summary>
  public class DalRepository<T> : IDalRepository<T>
    where T : new()
  {
    const string classCode = "[1002500]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Locker object for integrity write to database
    /// </summary>
    protected static object locker = new object();

    /// <summary>
    /// SQLite database connection
    /// </summary>
    protected SQLiteConnection database;
    /// <summary>
    /// Load entity from database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    public void Load<T>(T entity)
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// Save entity to database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    public void Save<T>(T entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
