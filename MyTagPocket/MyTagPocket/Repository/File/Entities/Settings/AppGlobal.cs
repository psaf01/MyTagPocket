namespace MyTagPocket.Storage.Entities.Settings
{
  /// <summary>
  /// Global setting application
  /// </summary>
  public class AppGlobal : FileEntityBase
  {

    /// <summary>
    /// Constructor
    /// </summary>
    public AppGlobal() : base(CoreUtil.DataTypeEnum.SETTINGS)
    { }

    /// <summary>
    /// Version application
    /// </summary>
    public string Version { get; set; }
  }
}
