using MyTagPocket.CoreUtil;

namespace MyTagPocket.Repository.File.Entities.Contents
{
  /// <summary>
  /// Version application
  /// </summary>
  [FileVersion(1)]
  public class Version : VersionBase<Version>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Version() : base(DataTypeEnum.CONTENTS, SystemEntityGuidConst.ContentsVersion)
    { }

    #region Public attributest
    #endregion Public atributes

    #region Public method
    /// <summary>
    /// Deserialice JSON string to file entity
    /// </summary>
    /// <param name="jsonString">JSON</param>
    /// <returns>File Entity</returns>
    public override Version DeserializeJson(string jsonString)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Version>(jsonString);
    }
    #endregion Public method
  }
}
