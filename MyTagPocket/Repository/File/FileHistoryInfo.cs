using MyTagPocket.Repository.File.Interface;

namespace MyTagPocket.Repository.File
{
  /// <summary>
  /// Information about File history 
  /// </summary>
  public class FileHistoryInfo : IFileHistoryInfo
  {
    #region Properties
    /// <summary>
    /// GUID file
    /// </summary>
    public string FileId { get; set; }

    /// <summary>
    /// File type 
    /// </summary>
    public string FileType { get; set; }

    /// <summary>
    /// GUID Commit
    /// </summary>
    public string CommitId { get; set; }

    /// <summary>
    /// Create date commit
    /// </summary>
    public string CreateDate { get; set; }

    /// <summary>
    /// Start position content binary in archive file
    /// </summary>
    public int StartPosition { get; set; }

    /// <summary>
    /// Length content
    /// </summary>
    public int LengthContent { get; set; }

    /// <summary>
    /// Entity update who
    /// </summary>
    public string CreatedWho { get; set; }
    #endregion Properties

    #region Public Method
    /// <summary>
    /// Deserialice JSON string to file entity
    /// </summary>
    /// <param name="jsonString">JSON</param>
    /// <returns>File Entity</returns>
    public FileHistoryInfo DeserializeJson(string jsonString)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<FileHistoryInfo>(jsonString);
    }
    #endregion Public Method
  }
}
