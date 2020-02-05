namespace MyTagPocket.Repository.FullText.Interface
{
  /// <summary>
  /// Interface for base entity fulltext
  /// </summary>
  public interface IFullTextBase
  {
    /// <summary>
    /// Identification entity in fulltext
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Name collection fulltext
    /// </summary>
    string GetNameCollection { get; }
  }
}
