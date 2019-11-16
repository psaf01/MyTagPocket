using MyTagPocket.CoreUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Repository.Dal.Entities.App
{
  /// <summary>
  /// Audit log item
  /// </summary>
  public class Audit : DalBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Audit(): base(nameCollectionEntity: "audit")
    { }

    /// <summary>
    /// Audit code
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Data type
    /// </summary>
    public DataTypeEnum DataType { get; set; }

    /// <summary>
    /// Parameters values
    /// </summary>
    public string[] Parameters { get; set; }

    /// <summary>
    /// Date time created
    /// </summary>
    public DateTimeOffset CreatedWhen { get; set; }

    /// <summary>
    /// GUID device
    /// </summary>
    public string DeviceGuid { get; set; }

    /// <summary>
    /// GUID user
    /// </summary>
    public string UserGuid { get; set; }
  }
}
