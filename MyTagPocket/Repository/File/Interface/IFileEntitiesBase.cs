using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Entities.Devices;
using MyTagPocket.Repository.File.Entities.Users;
using System;

namespace MyTagPocket.Repository.File.Interface
{
  /// <summary>
  /// Interface file entities base for
  /// </summary>
  public interface IFileEntityBase<T>
  {
    /// <summary>
    /// version of the class/entity definition structure
    /// </summary>
    int Version { get; set; }

    /// <summary>
    /// Identification entity GUID
    /// </summary>
    string EntityId { get; set; }

    /// <summary>
    /// Identification folder GUID
    /// </summary>
    string FolderId { get; set; }

    /// <summary>
    /// Full path to file with name
    /// </summary>
    string FullPathFile { get; set; }

    /// <summary>
    /// Identification commit GUID
    /// </summary>
    string CommitId { get; set; }

    /// <summary>
    /// Get type entity
    /// </summary>
    DataTypeEnum TypeEntity { get; set; }

    /// <summary>
    /// Entity created when
    /// </summary>
    DateTimeOffset CreatedWhen { get; set; }

    /// <summary>
    /// Entity updated when
    /// </summary>
    DateTimeOffset UpdatedWhen { get; set; }

    /// <summary>
    /// Entity update who GUID
    /// </summary>
    UserBasicInfo CreatedWho { get; set; }

    /// <summary>
    /// Entity updated who GUID
    /// </summary>
    UserBasicInfo UpdatedWho { get; set; }

    /// <summary>
    /// On which device the object was created GUID
    /// </summary>
    DeviceBasicInfo CreatedDevice { get; set; }

    /// <summary>
    /// On which device the object was updated GUID
    /// </summary>
    DeviceBasicInfo UpdatedDevice { get; set; }

    /// <summary>
    /// Hash entity
    /// </summary>
    string Hash { get; set; }

    /// <summary>
    /// Encrypt file
    /// </summary>
    EncryptTypeEnum Encrypt { get; set; }

    /// <summary>
    /// Deserialice JSON string to file entity
    /// </summary>
    /// <param name="jsonString">JSON</param>
    /// <returns>File Entity</returns>
    T DeserializeJson(string jsonString);

    /// <summary>
    /// Serialize file entity to json string
    /// </summary>
    /// <typeparam name="T">File entity</typeparam>
    /// <returns>JSON string</returns>
    string SerializeJson();
  }
}
