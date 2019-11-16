namespace MyTagPocket.Repository.Dal.Entities.Settings
{
  /// <summary>
  /// Settings
  /// </summary>
  public class Setting : DalBase
  {
    public Setting() : base(nameCollectionEntity: "setting")
    {
    }

    /// <summary>
    /// Name setting
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Int value
    /// </summary>
    public decimal Number { get; set; }

    /// <summary>
    /// Text value
    /// </summary>
    public string Text { get; set; }
  }
}
