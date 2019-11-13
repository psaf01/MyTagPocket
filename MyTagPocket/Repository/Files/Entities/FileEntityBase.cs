using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.Files.Entities.Devices;
using MyTagPocket.Repository.Files.Entities.Users;
using MyTagPocket.Repository.Files.Interfaces;
using Newtonsoft.Json;
using System;

namespace MyTagPocket.Repository.Files.Entities
{
  /// <summary>
  /// Base Entities
  /// </summary>
  public class FileEntityBase<T> : IFileEntityBase<T>
  {
    #region Private variable
  
   #endregion Private variable

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dataTypeEntities">Data type entity</param>
    /// <param name="idEntity">ID entity. Unique code</param>
    public FileEntityBase(DataTypeEnum dataTypeEntities, string entityId, EncryptTypeEnum encrypt, int version)
    {
      TypeEntity = dataTypeEntities;
      Encrypt = encrypt;
      EntityId = entityId;
      Version = version;

      if (EntityId == null)
      {
        //create new ID
        EntityId = Guid.NewGuid().ToString("N");
        CreatedWhen = DateTimeOffset.Now;
        UpdatedWhen = CreatedWhen;
        CreatedWho = new UserBasicInfo();
        UpdatedWho = CreatedWho;
      }
    }
    #endregion Constructor

    #region Public property

    /// <summary>
    /// version of the class/entity definition structure
    /// </summary>
    [JsonProperty("v")]
    public int Version { get; set; }

    /// <summary>
    /// Identification entity
    /// </summary>
    [JsonProperty("eid")]
    public string EntityId { get; set; }

    /// <summary>
    /// Identification folder GUID
    /// </summary>
    [JsonProperty("fid")]
    public string FolderId { get; set; }

    /// <summary>
    /// Full path to file with name
    /// </summary>
    [JsonIgnore]
    public string FullPathFile { get; set; }

    /// <summary>
    /// Identification commit
    /// </summary>
    [JsonProperty("cid")]
    public string CommitId { get; set; }

    /// <summary>
    /// Get type entity
    /// </summary>
    /// <returns>Data type entity</returns>
    [JsonProperty("te")]
    public DataTypeEnum TypeEntity { get; set; }

    /// <summary>
    /// Entity created when
    /// </summary>
    [JsonProperty("cw")]
    public DateTimeOffset CreatedWhen { get; set; }

    /// <summary>
    /// Entity updated when
    /// </summary>
    [JsonProperty("uw")]
    public DateTimeOffset UpdatedWhen { get; set; }

    /// <summary>
    /// Entity update who
    /// </summary>
    [JsonProperty("cwh")]
    public UserBasicInfo CreatedWho { get; set; }

    /// <summary>
    /// Entity updated who
    /// </summary>
    [JsonProperty("uwh")]
    public UserBasicInfo UpdatedWho { get; set; }

    /// <summary>
    /// On which device the object was created GUID
    /// </summary>
    [JsonProperty("cd")]
    public DeviceBasicInfo CreatedDevice { get; set; }

    /// <summary>
    /// On which device the object was updated GUID
    /// </summary>
    [JsonProperty("ud")]
    public DeviceBasicInfo UpdatedDevice { get; set; }

    /// <summary>
    /// Hash entity
    /// </summary>
    [JsonProperty("h")]
    public virtual string Hash { get; set; }

    /// <summary>
    /// File encrypt
    /// </summary>
    [JsonProperty("e")]
    public EncryptTypeEnum Encrypt { get; set; }
    #endregion Public property   

    #region Public method
    /// <summary>
    /// Get actual hash from entity 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return Version.GetHashCode() ^ UpdatedWhen.GetHashCode() ^ UpdatedWho.GetHashCode() ^ EntityId.GetHashCode();
    }

    /// <summary>
    /// Deserialice JSON string to file entity
    /// </summary>
    /// <param name="jsonString">JSON</param>
    /// <returns>File Entity</returns>
    public T DeserializeJson(string jsonString)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
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
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);//, jsSettings);
    }

    #endregion Public method

    #region Private method

    #endregion Private method
  }
}
