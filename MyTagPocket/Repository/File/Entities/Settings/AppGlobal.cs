using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Entities;

namespace MyTagPocket.Storage.Entities.Settings
{
  /// <summary>
  /// Global setting application
  /// </summary>
  public class AppGlobal : FileEntityBase<AppGlobal>
  {

    /// <summary>
    /// Constructor
    /// </summary>
    public AppGlobal() : base(CoreUtil.DataTypeEnum.Setting, SystemEntityGuidConst.AppGlobal, EncryptTypeEnum.None, 1)
    { }
  }
}
