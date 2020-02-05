using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Repository.FullText.Entities
{
  /// <summary>
  /// Word index
  /// </summary>
  public class WordIndex : FullTextBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public WordIndex() : base(nameCollectionEntity: "wordindex")
    {
    }

    /// <summary>
    /// Word name lowercase
    /// </summary>
    public string Name{ get;set; }

    /// <summary>
    /// Word name original case
    /// </summary>
    public string OriginalName { get; set; }

    /// <summary>
    /// Count word in fulltext
    /// </summary>
    public long Count { get; set; }

    /// <summary>
    /// Language ID
    /// </summary>
    public string LangId { get; set; }
  }
}
