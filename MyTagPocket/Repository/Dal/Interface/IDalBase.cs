using LiteDB;

namespace MyTagPocket.Repository.Dal.Interface
{
  /// <summary>
  /// Interface database layer base entity
  /// </summary>
  public interface IDalBase
  {
    /// <summary>
    /// Identification entity in database
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Name collection entity
    /// </summary>
    string GetNameCollection { get; }

  }
}
