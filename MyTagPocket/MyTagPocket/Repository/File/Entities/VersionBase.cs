using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Interface;
using Newtonsoft.Json;
using System.Reflection;

namespace MyTagPocket.Repository.File.Entities
{
  /// <summary>
  /// Version application
  /// </summary>
  public class VersionBase<T> : FileEntityBase<T>, IVersion
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
    [JsonProperty("v")]
    public int Version { get; set; }
    #endregion Public atributes

    #region Public method
    
    #endregion Public method
  }
}
