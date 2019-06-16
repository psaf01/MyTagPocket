using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Interface;
using System;

namespace MyTagPocket.Repository.File.Entities
{
  /// <summary>
  /// Base Entities
  /// </summary>
  public class FileEntityBase : IFileEntityBase
  {
    #region Private variable
    /// <summary>
    /// Type Entity
    /// </summary>
    private DataTypeEnum _DataTypeEntity;

    /// <summary>
    /// ID entity. Unique code for Entity
    /// </summary>
    private string _IdEntity;

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
    /// <param name="id">ID entity. Unique code</param>
    public FileEntityBase(DataTypeEnum dataTypeEntities, string id, EncryptTypeEnum encrypt)
    {
      _DataTypeEntity = dataTypeEntities;
      _Encrypt = encrypt;
      _IdEntity = id;

      if (_IdEntity == null)
      {
        //create new ID
        _IdEntity = $"{_DataTypeEntity.Name.Substring(0, 1)}{DateTime.Now.ToString("YYYYMMDD")}{Guid.NewGuid().ToString()}";
      }

    }
    #endregion Constructor

    #region Public property
    /// <summary>
    /// Identification entity
    /// </summary>
    public string IdEntity { get => _IdEntity; set => _IdEntity = value; }

    /// <summary>
    /// Get type entity
    /// </summary>
    /// <returns>Data type entity</returns>
    public DataTypeEnum TypeEntity { get => _DataTypeEntity; set => _DataTypeEntity = value; }

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
    /// Version entity in history
    /// </summary>
    public long VersionObject { get; set; }
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
    /// Get type encrypt entity
    /// </summary>
    /// <returns>Encrypt entity</returns>
    public EncryptTypeEnum GetEncrypt()
    {
      return _Encrypt;
    }
    #endregion Public method

    #region Private method

    #endregion Private method
  }
}
