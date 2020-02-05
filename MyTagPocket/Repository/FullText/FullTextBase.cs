using MyTagPocket.Repository.FullText.Interface;

namespace MyTagPocket.Repository.FullText
{
  public class FullTextBase : IFullTextBase
  {
    private string nameCollection;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nameCollection"></param>
    public FullTextBase(string nameCollectionEntity)
    {
      nameCollection = nameCollectionEntity;
    }

    /// <summary>
    /// Identification entity in fullText
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get name collection
    /// </summary>
    public virtual string GetNameCollection
    {
      get
      {
        return nameCollection;
      }
    }
  }
}
