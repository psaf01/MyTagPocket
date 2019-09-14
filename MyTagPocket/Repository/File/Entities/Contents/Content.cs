using MyTagPocket.CoreUtil;

namespace MyTagPocket.Repository.File.Entities.Contents
{

  /// <summary>
  /// Content MyTagPocket
  /// </summary>
  public class Content : FileEntityBase<Content>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Content() : base(DataTypeEnum.CONTENTS, null, EncryptTypeEnum.NONE)
    { }

    #region Public attributest
    /// <summary>
    /// Content value
    /// </summary>
    public string Value { get; set; }

    #endregion Public atributes

    #region Public method
    /// <summary>
    /// Generat hash code of content
    /// </summary>
    /// <returns></returns>
    public override string GetActualHash()
    {
      return (Value.GetHashCode() ^ UpdatedWhen.GetHashCode()).ToString();
    }
    #endregion Public method
  }
}
