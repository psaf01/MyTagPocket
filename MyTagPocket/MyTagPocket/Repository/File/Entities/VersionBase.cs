using MyTagPocket.CoreUtil;
using System.Reflection;

namespace MyTagPocket.Repository.File.Entities
{
  /// <summary>
  /// Version application
  /// </summary>
  public class VersionBase : FileEntityBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public VersionBase(DataTypeEnum dataType, string guid) : base(dataType, guid, EncryptTypeEnum.NONE)
    { }

    #region Public attributest
    /// <summary>
    /// Version
    /// </summary>
    public string Ver { get; set; }
    #endregion Public atributes

    #region Public method
    
    #endregion Public method
  }
}
