using LiteDB;

namespace MyTagPocket.CoreUtil.Interfaces
{
  /// <summary>
  ///  Interface helper for fulltext system on device
  /// </summary>
  public interface IFullTextHelper
  {
    LiteDatabase OpenDB();
  }
}
