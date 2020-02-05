using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Repository.FullText.Entities
{
  /// <summary>
  /// Catalog index bettween 
  /// </summary>
  public class CatalogIndex : FullTextBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public CatalogIndex() : base(nameCollectionEntity: "catalogindex")
    { }

    /// <summary>
    /// Identification word 
    /// </summary>
    public int WordId { get; set; }

    /// <summary>
    /// Score word in content
    /// </summary>
    public double Score { get; set; }

    /// <summary>
    /// Language identifikation
    /// </summary>
    public int LangId { get; set; }
  }
}
