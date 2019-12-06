using LiteDB;

namespace MyTagPocket.CoreUtil.Interfaces
{
  /// <summary>
  ///  Intrface helper for database system on device
  /// </summary>
  public interface IDalHelper
  {
    LiteDatabase OpenDB();
  }
}
