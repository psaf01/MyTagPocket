using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Interface;
using System;

namespace MyTagPocket.Repository.File.Entities
{
  /// <summary>
  /// Base Entities
  /// </summary>
  public class FileEntityBase<T> : IFileEntityBase<T>
  {
    #region Private variable
    /// <summary>
    /// Type Entity
    /// </summary>

    /// <summary>
    /// Define encrypt entity
    /// </summary>
    private EncryptTypeEnum _Encrypt;

    /// <summary>
    /// Hash entity
    /// </summary>
    private string _Hash;
    #endregion Private variable

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dataTypeEntities">Data type entity</param>
    /// <param name="idEntity">ID entity. Unique code</param>
    public FileEntityBase(DataTypeEnum dataTypeEntities, string entityId, EncryptTypeEnum encrypt)
    {
      TypeEntity = dataTypeEntities;
      _Encrypt = encrypt;
      EntityId = entityId;

      if (EntityId == null)
      {
        //create new ID
        EntityId = Guid.NewGuid().ToString();
      }

    }
    #endregion Constructor

    #region Public property
    /// <summary>
    /// Identification entity
    /// </summary>
   public  string EntityId { get; set; }

    /// <summary>
    /// Identification commit
    /// </summary>
    public string CommitId { get; set; }

    /// <summary>
    /// Get type entity
    /// </summary>
    /// <returns>Data type entity</returns>
    public DataTypeEnum TypeEntity { get; set; }

    /// <summary>
    /// Entity created when
    /// </summary>
    public DateTime CreatedWhen { get; set; }

    /// <summary>
    /// Entity updated when
    /// </summary>
    public DateTime UpdatedWhen { get; set; }

    /// <summary>
    /// Entity update who
    /// </summary>
    public string CreatedWho { get; set; }

    /// <summary>
    /// Entity updated who
    /// </summary>
    public string UpdatedWho { get; set; }

    /// <summary>
    /// Hash entity
    /// </summary>
    public virtual string Hash { get; set; }

    /// <summary>
    /// File encrypt
    /// </summary>
    public EncryptTypeEnum Encrypt { get => _Encrypt; set => _Encrypt = value; }
    #endregion Public property   

    #region Public method
    /// <summary>
    /// Get actual hash from entity 
    /// </summary>
    /// <returns></returns>
    public virtual string GetActualHash()
    {
      return GetHashCode().ToString();
    }

    /// <summary>
    /// Deserialice JSON string to file entity
    /// </summary>
    /// <param name="jsonString">JSON</param>
    /// <returns>File Entity</returns>
    public virtual T DeserializeJson(string jsonString)
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
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    #endregion Public method

    #region Private method

    #endregion Private method
  }
}
