using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.Files.Entities;

namespace MyTagPocket.Repository.Entities.Settings
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
