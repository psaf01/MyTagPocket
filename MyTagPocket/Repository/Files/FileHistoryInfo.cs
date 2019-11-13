using MyTagPocket.Repository.Files.Interfaces;
using Newtonsoft.Json;

namespace MyTagPocket.Repository.Files
{
  /// <summary>
  /// Information about File history 
  /// </summary>
  public class FileHistoryInfo : IFileHistoryInfo
  {
    #region Properties
    /// <summary>
    /// Version object file history info
    /// </summary>
    [JsonProperty("v")]
    public int Version { get; set; }

    /// <summary>
    /// GUID file
    /// </summary>
    [JsonProperty("fid")]
    public string FileId { get; set; }

    /// <summary>
    /// GUID folder
    /// </summary>
    [JsonProperty("flid")]
    public string FolderId { get; set; }

    /// <summary>
    /// File type 
    /// </summary>
    [JsonProperty("ft")]
    public string FileType { get; set; }

    /// <summary>
    /// GUID Commit
    /// </summary>
    [JsonProperty("cit")]
    public string CommitId { get; set; }

    /// <summary>
    /// Create date commit
    /// </summary>
    [JsonProperty("cd")]
    public string CreatedDate { get; set; }

    /// <summary>
    /// Start position content binary in archive file
    /// </summary>
    [JsonProperty("sp")]
    public int StartPosition { get; set; }

    /// <summary>
    /// Length content
    /// </summary>
    [JsonProperty("lc")]
    public int LengthContent { get; set; }

    /// <summary>
    /// Entity update who Fullname
    /// </summary>
    [JsonProperty("cwf")]
    public string CreatedWhoFullname { get; set; }

    /// <summary>
    /// Entity update who e-mail
    /// </summary>
    [JsonProperty("cwe")]
    public string CreatedWhoEmail { get; set; }

    /// <summary>
    /// Identification who created
    /// </summary>
    [JsonProperty("cwi")]
    public string CreatedWhoId { get; set; }

    /// <summary>
    /// Name of device
    /// </summary>
    [JsonProperty("cdn")]
    public string CreatedOnDeviceName { get; set; }

    /// <summary>
    /// Identification 
    /// </summary>
    [JsonProperty("cdi")]
    public string CreatedOnDeviceId { get; set; }
    #endregion Properties

    #region Public Method
    /// <summary>
    /// Deserialice JSON string to file entity
    /// </summary>
    /// <param name="jsonString">JSON</param>
    /// <returns>File Entity</returns>
    public FileHistoryInfo DeserializeJson(string jsonString)
    {
      //JsonSerializerSettings jsSettings = new JsonSerializerSettings();
      //jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      //jsSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
      return JsonConvert.DeserializeObject<FileHistoryInfo>(jsonString);//, jsSettings);
    }

    /// <summary>
    /// Serialize file entity to json string
    /// </summary>
    /// <typeparam name="T">File entity</typeparam>
    /// <returns>JSON string</returns>
    public string SerializeJson()
    {
      //JsonSerializerSettings jsSettings = new JsonSerializerSettings();
      //jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      //jsSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);//, jsSettings);
    }
    #endregion Public Method
  }
}
