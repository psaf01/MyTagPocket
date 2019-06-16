using MyTagPocket.CoreUtil;
using SQLite;

namespace MyTagPocket.Dal.Entities
{
  /// <summary>
  /// Table version in app
  /// </summary>
  [TableVersion(1)]
  public class TableVersion
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public TableVersion()
    { }

    /// <summary>
    /// Identificator
    /// </summary>
    [PrimaryKey]//, AutoIncrement]
    //[JsonIgnore]
    public string Id { get; set; }

    /// <summary>
    /// Table name
    /// </summary>
    [NotNull]
    [Indexed(Name = "IX_TableName", Order = 1, Unique = true)]
    public string TableName { get; set; }

    /// <summary>
    /// Actual version table in database
    /// </summary>
    [NotNull]
    public int ActualVersion { get; set; }
  }
}
