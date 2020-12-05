using MyTagPocket.CoreUtil;
using System;
using System.Collections.Generic;

namespace MyTagPocket.Repository.Audit.Entities
{
  /// <summary>
  /// Audit log item
  /// </summary>
  public class Audit : AuditBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Audit() : base(nameCollectionEntity: "audit")
    {
      DataType = DataTypeEnum.Unclassified.Name;
      CreatedWhen = DateTimeOffset.Now;
      nameCollection = GenerateNameCollection();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nameCollection">Internal name object for database collection</param>
    public Audit(string nameCollection) : base(nameCollectionEntity: nameCollection)
    {
      DataType = DataTypeEnum.Unclassified.Name;
      CreatedWhen = DateTimeOffset.Now;
    }
    /// <summary>
    /// Audit code
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Data type
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    /// Parameters values 
    /// Key, Value
    /// </summary>
    public Dictionary<string, string> Parameters { get; set; }

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


    /// <summary>
    /// Generate name collection for audit
    /// </summary>
    /// <returns>Name</returns>
    public static string GenerateNameCollection()
    {
      DateTimeOffset dateTime = DateTimeOffset.Now;
      return $"audit{dateTime.Year.ToString("D4")}{dateTime.Month.ToString("D2")}";
    }

    /// <summary>
    /// Generate name collection for audit
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">Month</param>
    /// <returns>Name</returns>
    public static string GenerateNameCollection(int year, int month)
    {
      return $"audit{year.ToString("D4")}{ month.ToString("D2")}";
    }
  }
}
