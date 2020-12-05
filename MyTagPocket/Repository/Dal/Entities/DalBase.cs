using MyTagPocket.Repository.Dal.Interface;

namespace MyTagPocket.Repository.Dal.Entities
{
  /// <summary>
  /// Base object for LiteDb
  /// </summary>
  public class DalBase : IDalBase
  {
    private string nameCollection;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nameCollection"></param>
    public DalBase(string nameCollectionEntity)
    {
      nameCollection = nameCollectionEntity;
    }

    /// <summary>
    /// Identification entity in database
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get name collection
    /// </summary>
    public virtual string GetNameCollection()
    { 
        return nameCollection;
    }
  }
}
